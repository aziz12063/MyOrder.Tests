using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Components.Childs.Header
{
    public partial class OrderInfo : BaseFluxorComponent<OrderInfoState, FetchOrderInfoAction>
    {
        private IState<OrderInfoState> OrderInfoState => State;

        protected override FetchOrderInfoAction CreateFetchAction(string basketId)
        {
            return new FetchOrderInfoAction(basketId);
        }


        private string SelectedClient 
        {
            get => OrderInfoState.Value.BasketOrderInfo.Account.Value?.AccountId + " - " + OrderInfoState.Value.BasketOrderInfo.Account.Value?.Name + " - " +
                   OrderInfoState.Value.BasketOrderInfo.Account.Value?.ZipCode;
            set => throw new NotImplementedException();
        }

        private string SelectedContact
        {
            get => OrderInfoState.Value.BasketOrderInfo.Contact.Value?.FirstName + " - " + OrderInfoState.Value.BasketOrderInfo.Contact.Value?.LastName;
            set => throw new NotImplementedException();
        }
    }
}
