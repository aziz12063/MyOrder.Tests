using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class PriceInfo : FluxorComponentBase<PricesInfoState, FetchPricesInfoAction>
{
    private BasketPricesInfoDto? BasketPricesInfo { get; set; }
    private List<BasketValueDto?>? Coupons { get; set; }
    private List<BasketValueDto?>? WarrantyCostOptions { get; set; }
    private List<BasketValueDto?>? ShippingCostOptions { get; set; }
    private bool isLoading = true;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var rscState = RessourcesState?.Value;
        Coupons = rscState?.Coupons
            ?? throw new ArgumentNullException("Unexpected null for Coupons");
        WarrantyCostOptions = rscState?.WarrantyCostOptions
            ?? throw new ArgumentNullException("Unexpected null for WarrantyCostOptions");
        ShippingCostOptions = rscState?.ShippingCostOptions
            ?? throw new ArgumentNullException("Unexpected null for ShippingCostOptions");
    }
    protected override void CacheNewFields()
    {
        BasketPricesInfo = State?.Value.PricesInfo
            ?? throw new ArgumentNullException("Unexpected null for BasketOrderInfo object.");

        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    protected override FetchPricesInfoAction CreateFetchAction(PricesInfoState state) => new(state);

}
