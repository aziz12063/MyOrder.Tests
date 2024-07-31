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

        protected void OnBlurHandler(Field<object> field)
        {
            // Check if ProcedureCall is null or has less than 4 items
            if (field.ProcedureCall is null || field.ProcedureCall.Count < 4)
            {
                logger.LogWarning("ProcedureCall is either null or has less than 4 items.");
                return;
            }

            try
            {
                // Create a copy of the ProcedureCall list to ensure it's not modified in the process
                var procedureCall = field.ProcedureCall.ToList();

                var lastIndex = procedureCall.Count - 1;

                if (field.Value != null)
                {
                    procedureCall[lastIndex] = (string)field.Value;

                    Dispatcher.Dispatch(new PostProcedureCallAction(BasketId, procedureCall));
                }
                else
                {
                    logger.LogWarning("Field value is null.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred in OnBlurHandler.", ex);
            }
        }

        public void Dispose()
        {
            State.StateChanged -= OnStateChanged;
            BasketService.BasketIdChanged -= OnBasketIdChanged;
        }

        protected abstract TAction CreateFetchAction(string basketId);
    }

}
