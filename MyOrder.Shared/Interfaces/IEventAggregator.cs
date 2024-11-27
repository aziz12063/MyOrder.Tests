namespace MyOrder.Shared.Interfaces;

/// <summary>
/// Defines the contract for an event aggregator that manages event publishing and subscriptions.
/// </summary>
public interface IEventAggregator
{
    /// <summary>
    /// Subscribes to an event of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to subscribe to.</typeparam>
    /// <param name="action">The action to be invoked when the event is published.</param>
    void Subscribe<TEvent>(Action<TEvent> action);

    /// <summary>
    /// Unsubscribes from an event of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to unsubscribe from.</typeparam>
    /// <param name="action">The action that was previously subscribed.</param>
    void Unsubscribe<TEvent>(Action<TEvent> action);

    /// <summary>
    /// Sets a default handler for an event of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event for which the default handler is set.</typeparam>
    /// <param name="handler">The default action to be invoked if no subscribers are present.</param>
    void SetDefaultHandler<TEvent>(Action<TEvent> handler);

    /// <summary>
    /// Publishes an event of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to publish.</typeparam>
    /// <param name="eventToPublish">The event instance to publish.</param>
    void Publish<TEvent>(TEvent eventToPublish);

    /// <summary>
    /// Checks if there are any subscribers for an event of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to check for subscribers.</typeparam>
    /// <returns>True if there are subscribers; otherwise, false.</returns>
    bool HasSubscribers<TEvent>();
}
