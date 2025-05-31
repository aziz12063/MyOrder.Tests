using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.RessourcesUseCase;

[FeatureState]
public class RessourcesState : StateBase
{
    public List<BasketValueDto?>? CustomerTags { get; }
    public List<BasketValueDto?>? SalesOrigins { get; }
    public List<BasketValueDto?>? SalesPools { get; }
    public List<BasketValueDto?>? Countries { get; }
    public List<BasketValueDto?>? CarrierTypes { get; }
    public List<BasketValueDto?>? TaxGroups { get; }
    public List<BasketValueDto?>? PaymentModes { get; }
    public List<BasketValueDto?>? UpdateReasons { get; }
    public List<BasketValueDto?>? LogisticFlows { get; }
    public List<BasketValueDto?>? Coupons { get; }
    public List<BasketValueDto?>? WarrantyCostOptions { get; }
    public List<BasketValueDto?>? ShippingCostOptions { get; }

    public RessourcesState() : base(true) { }

    public RessourcesState(List<BasketValueDto?>? customerTags,
        List<BasketValueDto?>? salesOrigins,
        List<BasketValueDto?>? salesPools,
        List<BasketValueDto?>? countries,
        List<BasketValueDto?>? carrierTypes,
        List<BasketValueDto?>? taxGroups, 
        List<BasketValueDto?>? paymentModes,
        List<BasketValueDto?>? updateReasons, 
        List<BasketValueDto?>? logisticFlows,
        List<BasketValueDto?>? coupons,
        List<BasketValueDto?>? warrantyCostOptions,
        List<BasketValueDto?>? shippingCostOptions) : base(false)
    {
        CustomerTags = customerTags;
        SalesOrigins = salesOrigins;
        SalesPools = salesPools;
        Countries = countries;
        CarrierTypes = carrierTypes;
        TaxGroups = taxGroups;
        PaymentModes = paymentModes;
        UpdateReasons = updateReasons;
        LogisticFlows = logisticFlows;
        Coupons = coupons;
        WarrantyCostOptions = warrantyCostOptions;
        ShippingCostOptions = shippingCostOptions;
    }



}
