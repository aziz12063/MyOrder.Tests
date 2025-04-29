namespace MyOrder.Shared.Interfaces;

/// <summary>
/// Central dispatcher for in‐process events.  
/// Handlers can be registered for a given event type and will be 
/// invoked whenever <see cref="PublishAsync{TEvent}(TEvent)"/> is called.
/// </summary>
public interface IEventAggregator
{
    /// <summary>
    /// Subscribes an asynchronous handler for events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">
    /// The type of event to listen for.
    /// </typeparam>
    /// <param name="handler">
    /// A <see cref="Func{TEvent,Task}"/> to invoke when the event is published.
    /// </param>
    /// <returns>
    /// An <see cref="IDisposable"/> which, when disposed, will unsubscribe this handler.
    /// </returns>
    IDisposable Subscribe<TEvent>(Func<TEvent, Task> handler);

    /// <summary>
    /// Subscribes a synchronous handler for events of type <typeparamref name="TEvent"/>.
    /// Handlers registered here will be wrapped into a <see cref="Task"/> automatically.
    /// </summary>
    /// <typeparam name="TEvent">
    /// The type of event to listen for.
    /// </typeparam>
    /// <param name="handler">
    /// An <see cref="Action{TEvent}"/> to invoke when the event is published.
    /// </param>
    /// <returns>
    /// An <see cref="IDisposable"/> which, when disposed, will unsubscribe this handler.
    /// </returns>
    IDisposable Subscribe<TEvent>(Action<TEvent> handler);

    /// <summary>
    /// Publishes <paramref name="evt"/> to all currently subscribed handlers of that event type.
    /// Any <see cref="Exception"/> thrown by individual handlers is caught and logged; 
    /// publishing continues to all subscribers.
    /// </summary>
    /// <typeparam name="TEvent">
    /// The type of the event being published.
    /// </typeparam>
    /// <param name="evt">
    /// The event instance to dispatch; cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> that completes once all handlers have been invoked.
    /// </returns>
    Task PublishAsync<TEvent>(TEvent evt);

    /// <summary>
    /// Returns <c>true</c> if <see cref="PublishAsync{TEvent}(TEvent)"/> would
    /// find at least one handler for <typeparamref name="TEvent"/>; <c>false</c> otherwise.
    /// </summary>
    /// <typeparam name="TEvent">
    /// The event type to check for subscribers.
    /// </typeparam>
    bool HasSubscribers<TEvent>();
}