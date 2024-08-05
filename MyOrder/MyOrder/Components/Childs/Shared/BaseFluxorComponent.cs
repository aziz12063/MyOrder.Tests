using System.Collections.Immutable;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.ProcedureCallUseCase;

namespace MyOrder.Components.Childs.Shared
{
    public abstract class BaseFluxorComponent<TState, TAction> : ComponentBase, IDisposable where TState : class
    {
        [Inject]
        protected IState<TState> State { get; set; }
        [Inject]
        protected IDispatcher Dispatcher { get; set; }
        [Inject]
        protected BasketService BasketService { get; set; }
        [Inject]
        protected ILogger<BaseFluxorComponent<TState, TAction>> logger { get; set; }

        protected string BasketId => BasketService.BasketId;

        protected override void OnInitialized()
        {
            State.StateChanged += OnStateChanged;
            BasketService.BasketIdChanged += OnBasketIdChanged;
            Dispatcher.Dispatch(CreateFetchAction(BasketId));
        }

        protected virtual void OnStateChanged(object sender, EventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        private void OnBasketIdChanged(string basketId)
        {
            Dispatcher.Dispatch(CreateFetchAction(basketId));
        }

        protected bool IsHidden<T>(Field<T> field) => field.Status == "hidden";

        protected bool IsReadOnly<T>(Field<T> field) => field.Status == "readOnly";

        protected bool IsReadWrite<T>(Field<T> field) => field.Status == "readWrite";

        protected bool IsRequired<T>(Field<T> field) => field.Status == "required";

        protected void UpdateProcedureCall(string? newValue, List<string>? procedureCall)
        {
            if (procedureCall == null) return;

            if (procedureCall is { Count: > 0 })
            {
                procedureCall[^1] = newValue ?? string.Empty; // Update with the new value or empty string if null
                OnPropertyUpdatedHandler(procedureCall);
            }
        }
        protected void OnPropertyUpdatedHandler(List<string> procedureCall)
        {
            if (procedureCall is null || procedureCall.Count < 1)
            {
                logger.LogWarning("ProcedureCall is either null or has 0 item.");
                return;
            }

            logger.LogInformation("OnPropertyUpdatedHandler called for {procedure}", procedureCall);

            try
            {
                // ToList() to Create a copy of the ProcedureCall list ensuring it's not modified in the process
                Dispatcher.Dispatch(new PostProcedureCallAction(BasketId, procedureCall.ToList()));
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred in OnPropertyUpdatedHandler. {ex}", ex);
            }
        }
        protected static string NullOrWhiteSpaceHelper(string? value) => string.IsNullOrWhiteSpace(value) ? "-" : value;
        public void Dispose()
        {
            State.StateChanged -= OnStateChanged;
            BasketService.BasketIdChanged -= OnBasketIdChanged;
        }

        protected abstract TAction CreateFetchAction(string basketId);
    }

}
