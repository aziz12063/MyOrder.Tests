using Microsoft.Extensions.Logging;
using MyOrder.Shared.Interfaces;
using System.Collections.Concurrent;

namespace MyOrder.Shared.Services;

public class EventAggregator(ILogger<EventAggregator> logger) : IEventAggregator
{
    private readonly ConcurrentDictionary<Type, List<Delegate>> _subscribers = new();
    private readonly ConcurrentDictionary<Type, Delegate> _defaultHandlers = new();
    private readonly object _subscriptionLock = new();
    private readonly ILogger<EventAggregator> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public void Subscribe<TEvent>(Action<TEvent> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var eventType = typeof(TEvent);

        lock (_subscriptionLock)
        {
            // Add or update the list of subscribers for the given event type
            _subscribers.AddOrUpdate(eventType,
                _ => [action],
                (_, list) =>
                {
                    list.Add(action);
                    return list;
                });
        }
    }

    public void Unsubscribe<TEvent>(Action<TEvent> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var eventType = typeof(TEvent);

        lock (_subscriptionLock)
        {
            if (_subscribers.TryGetValue(eventType, out var actions))
            {
                // Remove the specified action from the subscriber list
                actions.RemoveAll(a => a.Equals(action));
                if (actions.Count == 0)
                {
                    // Remove the event type if there are no more subscribers
                    _subscribers.TryRemove(eventType, out _);
                }
            }
        }
    }

    public void SetDefaultHandler<TEvent>(Action<TEvent> handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        var eventType = typeof(TEvent);
        // Set a default handler for the specified event type
        _defaultHandlers[eventType] = handler;
    }

    public void Publish<TEvent>(TEvent eventToPublish)
    {
        ArgumentNullException.ThrowIfNull(eventToPublish);
        var eventType = typeof(TEvent);

        if (_subscribers.TryGetValue(eventType, out var actions))
        {
            foreach (var action in actions)
            {
                try
                {
                    ((Action<TEvent>)action)(eventToPublish);
                }
                catch (Exception ex)
                {
                    // Log exceptions thrown by subscribers to ensure they do not affect the publisher
                    _logger.LogError(ex, "Subscriber threw an exception for event {EventType}", eventType.Name);
                }
            }
        }
        else if (_defaultHandlers.TryGetValue(eventType, out var defaultHandler))
        {
            try
            {
                ((Action<TEvent>)defaultHandler)(eventToPublish);
            }
            catch (Exception ex)
            {
                // Log exceptions thrown by the default handler to ensure they do not affect the publisher
                _logger.LogError(ex, "Default handler threw an exception for event {EventType}", eventType.Name);
            }
        }
        else
        {
            // Log a warning if no subscribers or default handler exist for the event type
            _logger.LogWarning("Unhandled event of type {EventType}", eventType.Name);
        }
    }

    public bool HasSubscribers<TEvent>()
    {
        // Check if there are any subscribers for the specified event type
        return _subscribers.TryGetValue(typeof(TEvent), out var actions) && actions.Count > 0;
    }
}
