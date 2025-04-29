using Microsoft.Extensions.Logging;
using MyOrder.Shared.Interfaces;
using System.Collections.Concurrent;

namespace MyOrder.Shared.Services;

/// <inheritdoc />
public class EventAggregator(ILogger<EventAggregator> logger) : IEventAggregator
{
    private readonly ConcurrentDictionary<Type, List<Delegate>> _subscribers = new();
    private readonly object _subscriptionLock = new();
    private readonly ILogger<EventAggregator> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    /// <inheritdoc />
    public IDisposable Subscribe<TEvent>(Func<TEvent, Task> asyncHandler)
    {
        ArgumentNullException.ThrowIfNull(asyncHandler);
        AddHandler(asyncHandler);
        return new Subscription(() => RemoveHandler(asyncHandler));
    }

    /// <inheritdoc />
    public IDisposable Subscribe<TEvent>(Action<TEvent> syncHandler)
    {
        ArgumentNullException.ThrowIfNull(syncHandler);

        // Wrap sync handler into a Task-returning delegate
        Func<TEvent, Task> wrapper = evt =>
        {
            syncHandler(evt);
            return Task.CompletedTask;
        };

        AddHandler(wrapper);
        return new Subscription(() => RemoveHandler(wrapper));
    }


    private void AddHandler<TEvent>(Func<TEvent, Task> handler)
    {
        var eventType = typeof(TEvent);
        lock (_subscriptionLock)
        {
            _subscribers.AddOrUpdate(
                eventType,
                _ => [handler],
                (_, list) =>
                {
                    list.Add(handler);
                    return list;
                });
        }
    }

    private void RemoveHandler<TEvent>(Func<TEvent, Task> handler)
    {
        var eventType = typeof(TEvent);
        lock (_subscriptionLock)
        {
            if (_subscribers.TryGetValue(eventType, out var list))
            {
                list.RemoveAll(d => d.Equals(handler));
                if (list.Count == 0)
                    _subscribers.TryRemove(eventType, out _);
            }
        }
    }

    /// <inheritdoc />
    public async Task PublishAsync<TEvent>(TEvent evt)
    {
        ArgumentNullException.ThrowIfNull(evt);

        var eventType = typeof(TEvent);
        List<Delegate>? snapshot = null;

        // Take a quick snapshot under lock
        lock (_subscriptionLock)
        {
            if (_subscribers.TryGetValue(eventType, out var handlers))
                snapshot = new List<Delegate>(handlers);
        }

        if (snapshot is null || snapshot.Count == 0)
        {
            _logger.LogWarning("No subscribers for event {Event}", eventType.Name);
            return;
        }

        // Invoke all handlers in parallel, isolating exceptions
        var tasks = snapshot.Select(async del =>
        {
            try
            {
                await ((Func<TEvent, Task>)del)(evt).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Subscriber threw for {Event}", eventType.Name);
            }
        });

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public bool HasSubscribers<TEvent>()
        => _subscribers.TryGetValue(typeof(TEvent), out var list)
           && list.Count > 0;

    /// <summary>
    /// Lightweight <see cref="IDisposable"/> that calls back to remove a subscription.
    /// </summary>
    private class Subscription(Action unsubscribe) : IDisposable
    {
        private readonly Action _unsubscribe = unsubscribe;
        private bool _disposed;

        public void Dispose()
        {
            if (!_disposed)
            {
                _unsubscribe();
                _disposed = true;
            }
        }
    }
}
