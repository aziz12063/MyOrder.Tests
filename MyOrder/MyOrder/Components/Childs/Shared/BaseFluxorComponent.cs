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

    protected void UpdateProcedureCall(string newValue, List<string>? procedureCall)
    {
        if (procedureCall is { Count: > 0 })
        {
            procedureCall[^1] = newValue ?? string.Empty; // Update with the new value or empty string if null
            OnPropertyUpdatedHandler(procedureCall);
        }
    }
    protected void OnPropertyUpdatedHandler(List<string> procedureCall)// this method is called only from UpdateProcedureCall
                                                                       // and we already check for:  if (procedureCall is { Count: > 0 })
    {
        if (procedureCall is null || procedureCall.Count < 1)           // so no need for this check
        {
            Logger.LogWarning("ProcedureCall is either null or has 0 item.");
            return;
        }

        Logger.LogInformation("OnPropertyUpdatedHandler called for {procedure}", procedureCall);

        try
        {
            // ToList() to Create a copy of the ProcedureCall list ensuring it's not modified in the process
            Dispatcher.Dispatch(new PostProcedureCallAction(BasketId, procedureCall.ToList()));
        }
        catch (Exception ex)
        {
            Logger.LogError("An error occurred in OnPropertyUpdatedHandler. {ex}", ex);
        }
    }

    public void Dispose()
    {
        State.StateChanged -= OnStateChanged;
        BasketService.BasketIdChanged -= OnBasketIdChanged;
    }

    protected abstract TAction CreateFetchAction(TState state, string basketId);
}