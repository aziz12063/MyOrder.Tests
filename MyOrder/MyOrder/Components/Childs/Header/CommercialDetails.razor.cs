using Fluxor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Components.Childs.Header
{
    public partial class CommercialDetails //: BaseFluxorComponent<TradeInfoState, FetchTradeInfoAction>
    {
        //private BasketTradeInfoDto? BasktTradeInfoDto => State.Value.BasketTradeInfo;
        //private List<BasketTurnoverLineDto?>? Turnover => BasktTradeInfoDto?.Turnover?.Value;

        //protected override FetchTradeInfoAction CreateFetchAction(string basketId)
        //{
        //    return new FetchTradeInfoAction(basketId);
        //}
        private List<BasketTurnoverLineDto> Turnover = new List<BasketTurnoverLineDto>
        {
            new BasketTurnoverLineDto
            {
                Name = "Product A",
                Ytd = "1000",
                YtdN1 = "1200",
                N1 = "800",
                N2 = "600"
            },
    new BasketTurnoverLineDto
    {
        Name = "Product B",
        Ytd = "1500",
        YtdN1 = "1300",
        N1 = "1100",
        N2 = "900"
    },
    new BasketTurnoverLineDto
    {
        Name = "Product C",
        Ytd = "2000",
        YtdN1 = "1800",
        N1 = "1600",
        N2 = "1400"
    },
    new BasketTurnoverLineDto
    {
        Name = "Product D",
        Ytd = "2500",
        YtdN1 = "2300",
        N1 = "2100",
        N2 = "1900"
    },
        new BasketTurnoverLineDto
        {
            Name = "Product E",
            Ytd = "3000",
            YtdN1 = "2800",
            N1 = "2600",
            N2 = "2400"
        }
     };

        

    }
}

