using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;
using MyOrder.Shared.Utils;
using MyOrder.Store.RessourcesUseCase;

namespace MyOrder.Components.Common;

public abstract class BaseFluxorComponent<TState, TAction> : ComponentBase, IDisposable where TState : class
{
    [Inject]
    protected IState<TState>? State { get; set; }
    [Inject]
    protected IState<RessourcesState>? RessourcesState { get; set; }
    [Inject]
    protected IDispatcher Dispatcher { get; set; }
    [Inject]
    protected BasketService BasketService { get; set; }
    [Inject]
    protected ILogger<BaseFluxorComponent<TState, TAction>> Logger { get; set; }

    protected Type FetchActionType { get; } = typeof(TAction);
    protected string BasketId => BasketService.BasketId;

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

    [Obsolete]
    protected void SetBasketOrderValue<T>(Field<T>? field, T value, string? procedureCallValue)
    {
        throw new NotImplementedException();
    }


    protected static string GetFieldValue(string? value) => FieldUtility.NullOrWhiteSpaceHelper(value);

    public void Dispose()
    {
        State.StateChanged -= OnStateChanged;
        BasketService.BasketIdChanged -= OnBasketIdChanged;
    }

    protected abstract TAction CreateFetchAction(TState state, string basketId);
}