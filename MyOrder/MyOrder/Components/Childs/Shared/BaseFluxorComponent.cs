using System.Collections.Immutable;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Shared;

public abstract class BaseFluxorComponent<TState, TAction> : ComponentBase, IDisposable where TState : class
{
    [Inject]
    protected IState<TState> State { get; set; }
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

    protected virtual void OnStateChanged(object? sender, EventArgs e) => InvokeAsync(StateHasChanged);


    private void OnBasketIdChanged(string basketId) => Dispatcher.Dispatch(CreateFetchAction(State.Value, basketId));

    protected void SetBasketOrderValue<T>(Field<T>? field, T value, string? procedureCallValue)
    {
        if (field == null)
        {
            Logger.LogWarning("Trying to update a null field at {StackTrace}", LogUtility.GetStackTrace());
            return;
        }

        // Set the field value
        field.Value = value;

#pragma warning disable CS0618 // Type or member is obsolete
        UpdateProcedureCall(procedureCallValue, field.ProcedureCall);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    // This method should only be called from SetBasketOrderValue, make private and remove the Obsolete attribute once the method is no longer used
    [Obsolete("Use SetBasketOrderValue instead", false)]
    protected void UpdateProcedureCall(string? newValue, List<string?>? procedureCall)
    {
        if (procedureCall is null || procedureCall.Count < 1)
        {
            Logger.LogWarning("ProcedureCall is either null or has 0 item.");
            return;
        }

        procedureCall[^1] = newValue ?? string.Empty; // Update with the new value or empty string if null
        OnPropertyUpdatedHandler(procedureCall);
    }

    private void OnPropertyUpdatedHandler(List<string?> procedureCall)
    {
        if (procedureCall.Any(item => item == null))
            Logger.LogWarning("ProcedureCall contains a null item.");

        Logger.LogInformation("OnPropertyUpdatedHandler called for {procedure}", procedureCall);

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