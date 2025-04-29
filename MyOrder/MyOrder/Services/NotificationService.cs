using Fluxor;
using MyOrder.Shared.Attributes;
using MyOrder.Shared.Enums;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.GlobalOperationsUseCase;
using System.Reflection;

namespace MyOrder.Services;

public sealed class NotificationService : INotificationService, IDisposable
{
    private readonly IEventAggregator _eventAggregator;
    private readonly IToastService _toastService;
    private readonly IModalService _modalService;
    private readonly ILogger<NotificationService> _logger;
    private readonly IDispatcher _dispatcher;

    private readonly List<IDisposable> _subscriptions = [];
    private bool _subscriptionInitialized = false;

    public NotificationService(IEventAggregator eventAggregator, IToastService toastService,
        IModalService modalService, ILogger<NotificationService> logger, IDispatcher dispatcher)
    {
        _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _toastService = toastService ?? throw new ArgumentNullException(nameof(toastService));
        _modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        if (_subscriptionInitialized)
        {
            _logger.LogWarning("Event subscription has already been initialized.");
            return;
        }

        _subscriptionInitialized = true;

        var methods = GetType()
          .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
          .Where(m => m.GetCustomAttributes(typeof(HandlesEventAttribute), false).Length != 0);

        foreach (var method in methods)
        {
            var attr = method.GetCustomAttribute<HandlesEventAttribute>()!;
            var eventType = attr.EventType;
            if (eventType is null)
            {
                _logger.LogWarning(
                    "Method {MethodName} is marked [HandlesEvent] but EventType was null.",
                    method.Name);
                continue;
            }

            // pick sync vs async overload
            bool returnsTask = typeof(Task).IsAssignableFrom(method.ReturnType);
            Type delegateType = returnsTask
                ? typeof(Func<,>).MakeGenericType(eventType, typeof(Task))
                : typeof(Action<>).MakeGenericType(eventType);

            // create your handler delegate
            var handlerDelegate = Delegate.CreateDelegate(delegateType, this, method);

            // find the correct Subscribe<TEvent>(…) overload
            var subscribeMethod = typeof(IEventAggregator)
                .GetMethods()
                .Where(m => m.Name == nameof(IEventAggregator.Subscribe)
                         && m.IsGenericMethodDefinition
                         && m.GetParameters().Length == 1
                         && m.GetParameters()[0].ParameterType.GetGenericTypeDefinition()
                              == (returnsTask ? typeof(Func<,>) : typeof(Action<>)))
                .Single()
                .MakeGenericMethod(eventType);

            // invoke and *capture* the IDisposable token
            var token = (IDisposable)subscribeMethod
                .Invoke(_eventAggregator, [handlerDelegate])!;

            _subscriptions.Add(token);
        }
    }

    public void ShowMessage(string message, NotificationType type = NotificationType.Info)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            _logger.LogWarning("Attempted to show a notification with an empty or null message.");
            return;
        }

        _logger.LogDebug("Showing notification of type {NotificationType}: {Message}", type, message);

        switch (type)
        {
            case NotificationType.Success:
                _toastService.ShowSuccess(message);
                break;
            case NotificationType.Warning:
                _toastService.ShowWarning(message);
                break;
            case NotificationType.Error:
                _toastService.ShowError(message);
                break;
            default:
                _toastService.ShowInfo(message);
                break;
        }
    }

    public void ShowProgress(string? message = null)
    {
        _logger.LogDebug("Displaying progress indicator with message: {Message}", message);
        //_modalService.ShowProgressModal(message);
        throw new NotImplementedException();
    }

    public void HideProgress()
    {
        _logger.LogDebug("Hiding progress indicator.");
        //_modalService.HideProgressModal();
        throw new NotImplementedException();
    }

    [HandlesEvent(typeof(ApiErrorEvent))]
    private void ShowInfrastructureError(ApiErrorEvent @event)
    {
        _dispatcher.Dispatch(new FaultAppAction(@event.Message));
        //_logger.LogError(@event.Exception, "An error occurred while processing a request to the API.");
        //_toastService.ShowError("An error occurred while processing a request to the API.");
    }

    public void Dispose()
    {
        foreach (var sub in _subscriptions)
        {
            try { sub.Dispose(); }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error disposing subscription token");
            }
        }
        _subscriptions.Clear();
    }
}