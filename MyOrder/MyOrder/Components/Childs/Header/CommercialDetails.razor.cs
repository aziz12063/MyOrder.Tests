using Fluxor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class CommercialDetails : FluxorComponentBase<TradeInfoState, FetchTradeInfoAction>
{

    private BasketTradeInfoDto? BasketTradeInfoDto { get; set; }
    private List<BasketTurnoverLineDto?>? Turnover { get; set; }
    private BasketContractInfoDto? Contract { get; set; }
    private string? DiscountDetails { get; set; }
    private bool isLoading = true;


    protected override FetchTradeInfoAction CreateFetchAction(TradeInfoState state, string basketId)
        => new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketTradeInfoDto = State.Value.BasketTradeInfo ?? throw new NullReferenceException("Unexpected null for BasketOrderInfo object.");
        Turnover = BasketTradeInfoDto?.Turnover?.Value;
        Contract = BasketTradeInfoDto?.Contract;
        DiscountDetails = FieldUtility.DisplayListNoSpace(Contract?.DiscountList?.Value);
        isLoading = State.Value.IsLoading;
    }

    private string ContractDescription
    {
        get => $"{Contract?.ContractId?.Name} {Contract?.ContractType?.Value}";
    }

}

