using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class PriceInfo : BaseFluxorComponent<PricesInfoState, FetchPricesInfoAction>
{
    private BasketPricesInfoDto? BasketPricesInfo { get; set; }
    private List<BasketValueDto?>? Coupons { get; set; }
    private List<BasketValueDto?>? WarrantyCostOptions { get; set; }
    private List<BasketValueDto?>? ShippingCostOptions { get; set; }
    private bool isLoading = true;

    protected override void CacheNewFields()
    {
        BasketPricesInfo = State.Value.PricesInfo 
            ?? throw new NullReferenceException("Unexpected null for BasketOrderInfo object.");
        Coupons = State.Value.Coupons;
        WarrantyCostOptions = State.Value.WarrantyCostOptions;
        ShippingCostOptions = State.Value.ShippingCostOptions;
        isLoading = State.Value.IsLoading;
    }

    protected override FetchPricesInfoAction CreateFetchAction(PricesInfoState state, string basketId) => new(state, basketId);

    private string CouponValue
    {
        get => GetFieldValue(BasketPricesInfo?.Coupon?.Value);
        set => SetBasketOrderValue(field: BasketPricesInfo!.Coupon, value: value, procedureCallValue: value);
    }
    private string WarrantyCostOptionsValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.WarrantyCostOption?.Value);
        //{
        //    var value = BasketPricesInfo?.WarrantyCostOption?.Value;
        //    return FieldUtility.NullOrWhiteSpaceHelper(
        //        WarrantyCostOptions?.FirstOrDefault(item => item?.Value == value)
        //        ?.Description);
        //}
        set => SetBasketOrderValue(field: BasketPricesInfo!.WarrantyCostOption, value: value, procedureCallValue: value);
    }
    private string ShippingCostOptionValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.ShippingCostOption?.Value);
        set => SetBasketOrderValue(field: BasketPricesInfo!.ShippingCostOption, value: value, procedureCallValue: value);
    }
    private decimal? ShippingCostAmountValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.ShippingCostAmount?.Value);
        set => SetBasketOrderValue(field: BasketPricesInfo!.ShippingCostAmount, value: value, procedureCallValue: value.ToString());
    }
    private int? OrderDiscountRateValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.OrderDiscountRate?.Value);
        set => SetBasketOrderValue(field: BasketPricesInfo!.OrderDiscountRate, value: value, procedureCallValue: value.ToString());
    }
}
