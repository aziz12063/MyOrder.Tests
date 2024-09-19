using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;
using MyOrder.Shared.Utils;

namespace MyOrder.Components.Common;

public abstract class BaseFluxorComponent<TState, TAction> : ComponentBase, IDisposable where TState : class
{
    [Inject]
    protected IState<TState>? State { get; set; }
    [Inject]
    protected IDispatcher Dispatcher { get; set; }
    [Inject]
    protected BasketService BasketService { get; set; }
    [Inject]
    protected ILogger<BaseFluxorComponent<TState, TAction>> Logger { get; set; }

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
        // Schedule the execution of this code on the Blazor UI thread. This ensures that any UI-related operations
        // are executed within the appropriate synchronization context, preventing potential threading issues.
        InvokeAsync(async () =>
        {
            // Cache the relevant state fields first to ensure they are up-to-date before the UI is re-rendered.
            // This prevents potential null reference issues when the Razor view attempts to access these fields.
            CacheNewFields();

            // Trigger a re-render of the component to reflect the updated state in the UI.
            // Awaiting this ensures that the state update happens after caching, maintaining consistency.
            await InvokeAsync(StateHasChanged);
        });
    }

    protected abstract void CacheNewFields();

    private void OnBasketIdChanged(string basketId) => Dispatcher.Dispatch(CreateFetchAction(State.Value, basketId));

    protected void SetBasketOrderValue<T>(Field<T>? field, T value, string? procedureCallValue)
    {
        if (field == null)
        {
            Logger.LogWarning("Trying to update a null field at {StackTrace}", LogUtility.GetStackTrace());
            return;
        }

        if (EqualityComparer<T>.Default.Equals(field.Value, value))
        {
            Logger.LogWarning("Trying to update the field with the same value at {StackTrace}", LogUtility.GetStackTrace());
            // Logger.LogWarning($"the updated  value is {value} and the old value is {field.Value}");
            return;
        }

        // Set the field value
        field.Value = value;
        try
        {
#pragma warning disable CS0618 // Type or member is obsolete
            UpdateProcedureCall(procedureCallValue, field.ProcedureCall);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        catch (ArgumentNullException e)
        {
            Logger.LogError(e, "Error while updating procedure call for {Field}", field);
        }

    }

    // This method should only be called from SetBasketOrderValue, make private and remove the Obsolete attribute once the method is no longer used
    private void UpdateProcedureCall(string? newValue, List<string?>? procedureCall)
    {
        if (procedureCall is null || procedureCall.Count < 1)
        {
            throw new ArgumentNullException(nameof(procedureCall), "ProcedureCall is either null or has 0 item.");
        }

        procedureCall[^1] = newValue ?? string.Empty; // Update with the new value or empty string if null

        bool pcdCallContainsNull = procedureCall
            .Take(procedureCall.Count - 2)
            .Any(item => item == null);

        if (pcdCallContainsNull)
            Logger.LogWarning("ProcedureCall contains a null item.");

        Logger.LogInformation("Dispatching procedure call:\n{procedure}", procedureCall);

        // ToList() to Create a copy of the ProcedureCall list ensuring it's not modified in the process
        Dispatcher.Dispatch(new PostProcedureCallAction(BasketId, procedureCall.ToList()));
    }

    protected static string GetFieldValue(string? value) => FieldUtility.NullOrWhiteSpaceHelper(value);

    public void Dispose()
    {
        State.StateChanged -= OnStateChanged;
        BasketService.BasketIdChanged -= OnBasketIdChanged;
    }

    protected abstract TAction CreateFetchAction(TState state, string basketId);
}