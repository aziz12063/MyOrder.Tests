using MyOrder.Shared.Attributes;
using MyOrder.Shared.Enums;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using System.Reflection;

namespace MyOrder.Services;

public class NotificationService : INotificationService
{
    private readonly IEventAggregator _eventAggregator;
    private readonly IToastService _toastService;
    private readonly IModalService _modalService;
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(IEventAggregator eventAggregator, IToastService toastService,
        IModalService modalService, ILogger<NotificationService> logger)
    {
        _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _toastService = toastService ?? throw new ArgumentNullException(nameof(toastService));
        _modalService = modalService ?? throw new ArgumentNullException(nameof(modalService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        try
        {
            var methods = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
              .Where(m => m.GetCustomAttributes(typeof(HandlesEventAttribute), false).Length != 0);

            foreach (var method in methods)
            {
                var attr = (HandlesEventAttribute?)method.GetCustomAttribute(typeof(HandlesEventAttribute));
                var eventType = attr?.EventType;

                if (eventType is null)
                {
                    _logger.LogWarning("Method {MethodName} is marked with the [HandlesEvent] attribute, but the EventType property is not set.", method.Name);
                    continue;
                }

                var subscribeMethod = typeof(IEventAggregator).GetMethod("Subscribe")?.MakeGenericMethod(eventType);

                if (subscribeMethod is null)
                {
                    _logger.LogError("Could not find the Subscribe method on the IEventAggregator interface.");
                }

                var handlerDelegate = Delegate.CreateDelegate(typeof(Action<>).MakeGenericType(eventType), this, method);

                subscribeMethod!.Invoke(_eventAggregator, [handlerDelegate]);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while subscribing to events.");
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
        _logger.LogError(@event.Exception, "An error occurred while processing a request to the API.");
        _toastService.ShowError("An error occurred while processing a request to the API.");
    }
}