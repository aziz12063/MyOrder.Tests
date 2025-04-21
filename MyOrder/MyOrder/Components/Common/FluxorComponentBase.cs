using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
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
    protected IBasketService BasketService { get; set; }
    [Inject]
    protected ILogger<FluxorComponentBase<TState, TAction>> Logger { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    protected Type FetchActionType { get; } = typeof(TAction);
    private bool _disposed = false;

    protected override async Task OnInitializedAsync()
    {
        State.StateChanged += OnStateChanged;
        Dispatcher.Dispatch(CreateFetchAction(State.Value));

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
            Logger.LogTrace("Cached new fields for {Component}", GetType().Name);
            // Trigger a re-render of the component to reflect the updated state in the UI.
            // Awaiting this ensures that the state update happens after caching, maintaining consistency.
            await InvokeAsync(StateHasChanged);
        });
        Logger.LogTrace("StateChanged handler completed for {Component}", GetType().Name);
    }

    protected abstract void CacheNewFields();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                State.StateChanged -= OnStateChanged;
            }

            _disposed = true;
        }
    }

    protected abstract TAction CreateFetchAction(TState state);
}