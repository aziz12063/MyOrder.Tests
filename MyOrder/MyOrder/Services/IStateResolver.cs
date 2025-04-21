using Fluxor;

namespace MyOrder.Services
{
    /// <summary>
    /// Provides methods for dispatching refresh actions related to various states in the application.
    /// This interface defines mechanisms to dispatch single or multiple refresh calls in a Fluxor state management context.
    /// </summary>
    public interface IStateResolver
    {
        /// <summary>
        /// Dispatches a batch of refresh calls based on a list of refresh keys.
        /// Each key corresponds to a specific state refresh action.
        /// </summary>
        /// <param name="dispatcher">
        /// The <see cref="IDispatcher"/> responsible for dispatching actions to the Fluxor store.
        /// </param>
        /// <param name="refreshCalls">
        /// A list of string keys representing the states to refresh.
        /// Null or empty entries in the list are ignored, and informative logs are generated.
        /// </param>
        /// <remarks>
        /// If the <paramref name="refreshCalls"/> list is null or empty, the method logs an informational message and exits without dispatching any actions.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a refresh key in the list is invalid or not mapped to any state action.
        /// </exception>
        void DispatchRefreshCalls(IDispatcher dispatcher, List<string?>? refreshCalls);

        /// <summary>
        /// Dispatches a specific refresh action for the given state key.
        /// </summary>
        /// <param name="dispatcher">
        /// The <see cref="IDispatcher"/> responsible for dispatching actions to the Fluxor store.
        /// </param>
        /// <param name="key">
        /// The string key identifying the state to refresh. This must match one of the predefined state keys in the implementation.
        /// </param>
        /// <remarks>
        /// The method looks up the associated action creators based on the provided key and dispatches all actions associated with that key.
        /// </remarks>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if the specified <paramref name="key"/> does not match any known state key.
        /// </exception>
        void DispatchRefreshAction(IDispatcher dispatcher, string key);
    }
}
