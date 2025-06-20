using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.TradeInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class TradeInfo : FluxorComponentBase<TradeInfoState, FetchTradeInfoAction>
{
    private const string VipIcon = "images/opportunity_120.png";
    private const string SpecialPrepIcon = "images/fulfillment_order_120.png";
    private const string ExportIcon = "images/custom20_120.png";
    private const string NoGiftIcon = "images/share_thanks_120.png";
    private const string CompleteDeliveryIcon = "images/checkout_120.png";
    private const string ContractGroupWarningIcon = "images/custom17_60.png";

    private BasketTradeInfoDto BasketTradeInfo => State.Value.BasketTradeInfo;
    private List<BasketTurnoverLineDto?>? Turnover => BasketTradeInfo?.Turnover?.Value;
    private BasketContractInfoDto? Contract => BasketTradeInfo?.Contract;
    private string? DiscountDetails => FieldUtility.DisplayListNoSpace(Contract?.DiscountList?.Value);

    protected override FetchTradeInfoAction CreateFetchAction()
        => new();

    private static string? CustomerTagIconHelper(string? value) => value switch
    {
        "vip" => VipIcon,
        "specialPrep" => SpecialPrepIcon,
        "export" => ExportIcon,
        "noGift" => NoGiftIcon,
        "completeDelivery" => CompleteDeliveryIcon,
        "contractGroupWarning" => ContractGroupWarningIcon,
        _ => null
    };

    private static string CustomerTagColorHelper(string? value) => value switch
    {
        "vip" => "background-color: #B8860B;",  // DarkGoldenrod (rich gold tone)
        "specialPrep" => "background-color: #EF6C00;",  // Orange800 (alert/prep work)
        "export" => "background-color: #1E88E5;",  // Blue600 (data-transfer)
        "noGift" => "background-color: #E53935;",  // Red600 (stop/no-gift)
        "completeDelivery" => "background-color: #43A047;",  // Green600 (success/done)
        "contractGroupWarning" => "background-color: #FDD835;",  // Yellow600 (warning)
        _ => "background-color: darkkhaki;" // fallback
    };
}