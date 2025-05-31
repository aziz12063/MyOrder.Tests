using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.RessourcesUseCase;

public class FetchRessourcesAction(RessourcesState state)
    : FetchDataActionBase(state)
{ }

public class FetchRessourcesSuccessAction(
    List<BasketValueDto?>? customerTags,
    List<BasketValueDto?>? salesOrigins,
    List<BasketValueDto?>? salesPools,
    List<BasketValueDto?>? deliveryCountries,
    List<BasketValueDto?>? carrierTypes,
    List<BasketValueDto?>? taxGroups,
    List<BasketValueDto?>? paymentModes,
    List<BasketValueDto?>? updateReasons,
    List<BasketValueDto?>? logisticFlows,
    List<BasketValueDto?>? coupons,
    List<BasketValueDto?>? warrantyCostOptions,
    List<BasketValueDto?>? shippingCostOptions)
{
    public List<BasketValueDto?>? CustomerTags { get; } = customerTags;
    public List<BasketValueDto?>? SalesOrigins { get; } = salesOrigins;
    public List<BasketValueDto?>? SalesPools { get; } = salesPools;
    public List<BasketValueDto?>? DeliveryCountries { get; } = deliveryCountries;
    public List<BasketValueDto?>? CarrierTypes { get; } = carrierTypes;
    public List<BasketValueDto?>? TaxGroups { get; } = taxGroups;
    public List<BasketValueDto?>? PaymentModes { get; } = paymentModes;
    public List<BasketValueDto?>? UpdateReasons { get; } = updateReasons;
    public List<BasketValueDto?>? LogisticFlows { get; } = logisticFlows;
    public List<BasketValueDto?>? Coupons { get; } = coupons;
    public List<BasketValueDto?>? WarrantyCostOptions { get; } = warrantyCostOptions;
    public List<BasketValueDto?>? ShippingCostOptions { get; } = shippingCostOptions;
}

public class FetchRessourcesFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
