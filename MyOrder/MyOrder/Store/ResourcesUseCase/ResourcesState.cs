using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.ResourcesUseCase;

[FeatureState]
public record ResourcesState(
    List<BasketValueDto?> ContactSalutations,
    List<BasketValueDto?> CustomerTags,
    List<BasketValueDto?> SalesOrigins,
    List<BasketValueDto?> SalesPools,
    List<BasketValueDto?> Countries,
    List<BasketValueDto?> CarrierTypes,
    List<BasketValueDto?> TaxGroups,
    List<BasketValueDto?> PaymentModes,
    List<BasketValueDto?> UpdateReasons,
    List<BasketValueDto?> LogisticFlows,
    List<BasketValueDto?> Coupons,
    List<BasketValueDto?> WarrantyCostOptions,
    List<BasketValueDto?> ShippingCostOptions) : StateBase
{

    public ResourcesState() : this([], [], [], [], [], [], [], [], [], [], [], [], []) { }
}