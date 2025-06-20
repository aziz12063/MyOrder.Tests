using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;

namespace MyOrder.Components.Childs.Header;

public partial class PriceInfo : FluxorComponentBase<PricesInfoState, FetchPricesInfoAction>
{
    private BasketPricesInfoDto? BasketPricesInfo => State.Value.PricesInfo;
    private List<BasketValueDto?>? Coupons { get; set; }
    private List<BasketValueDto?>? WarrantyCostOptions { get; set; }
    private List<BasketValueDto?>? ShippingCostOptions { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var rscState = ResourcesState.Value;
        Coupons = rscState.Coupons
            ?? throw new ArgumentNullException("Unexpected null for Coupons");
        WarrantyCostOptions = rscState?.WarrantyCostOptions
            ?? throw new ArgumentNullException("Unexpected null for WarrantyCostOptions");
        ShippingCostOptions = rscState?.ShippingCostOptions
            ?? throw new ArgumentNullException("Unexpected null for ShippingCostOptions");
    }

    protected override FetchPricesInfoAction CreateFetchAction() => new();

}
