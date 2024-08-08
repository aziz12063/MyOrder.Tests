using Fluxor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Components.Childs.Header
{
    public partial class CommercialDetails : BaseFluxorComponent<TradeInfoState, FetchTradeInfoAction>
    {
        private BasketTradeInfoDto? BasketTradeInfoDto => State.Value.BasketTradeInfo;
        private List<BasketTurnoverLineDto?>? Turnover => BasketTradeInfoDto?.Turnover?.Value;

        protected override FetchTradeInfoAction CreateFetchAction(string basketId)
        {
            return new FetchTradeInfoAction(basketId);
        }




    }
}

