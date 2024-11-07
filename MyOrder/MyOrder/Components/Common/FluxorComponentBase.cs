using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;
using MyOrder.Store.RessourcesUseCase;

namespace MyOrder.Components.Common;

public abstract class FluxorComponentBase<TState, TAction> : ComponentBase, IDisposable where TState : class
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Inject]
    protected IState<TState> State { get; set; }
    [Inject]
    protected IState<RessourcesState> RessourcesState { get; set; }
    [Inject]
    protected IDispatcher Dispatcher { get; set; }
    [Inject]
    protected BasketService BasketService { get; set; }
    [Inject]
    protected ILogger<FluxorComponentBase<TState, TAction>> Logger { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    protected Type FetchActionType { get; } = typeof(TAction);
    protected string BasketId => BasketService.BasketId;
    private bool disposed = false;

    protected override async Task OnInitializedAsync()
    {
        State.StateChanged += OnStateChanged;
        BasketService.BasketIdChanged += OnBasketIdChanged;
        Dispatcher.Dispatch(CreateFetchAction(State.Value, BasketId));

        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Handles state changes in the component by ensuring state fields are cached before triggering a UI update.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">Event arguments.</param>
    protected virtual void OnStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for {Component}", GetType().Name);
        // Schedule the execution of this code on the Blazor UI thread. This ensures that any UI-related operations
        // are executed within the appropriate synchronization context, preventing potential threading issues.
        InvokeAsync(async () =>
        {
            // Cache the relevant state fields first to ensure they are up-to-date before the UI is re-rendered.
            // This prevents potential null reference issues when the Razor view attempts to access these fields.
            CacheNewFields();
            Logger.LogDebug("Cached new fields for {Component}", GetType().Name);
            // Trigger a re-render of the component to reflect the updated state in the UI.
            // Awaiting this ensures that the state update happens after caching, maintaining consistency.
            await InvokeAsync(StateHasChanged);
        });
        Logger.LogDebug("StateChanged handler completed for {Component}", GetType().Name);
    }

    protected abstract void CacheNewFields();

    private void OnBasketIdChanged(string basketId) => Dispatcher.Dispatch(CreateFetchAction(State.Value, basketId));

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                State.StateChanged -= OnStateChanged;
                BasketService.BasketIdChanged -= OnBasketIdChanged;
            }

            disposed = true;
        }
    }

    protected abstract TAction CreateFetchAction(TState state, string basketId);
}