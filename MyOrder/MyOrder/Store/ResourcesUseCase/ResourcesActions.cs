using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.ResourcesUseCase;

public record FetchResourcesAction() : FetchDataActionBase;

public record FetchResourcesSuccessAction(
    List<BasketValueDto?> ContactSalutations,
    List<BasketValueDto?> CustomerTags,
    List<BasketValueDto?> SalesOrigins,
    List<BasketValueDto?> SalesPools,
    List<BasketValueDto?> DeliveryCountries,
    List<BasketValueDto?> CarrierTypes,
    List<BasketValueDto?> TaxGroups,
    List<BasketValueDto?> PaymentModes,
    List<BasketValueDto?> UpdateReasons,
    List<BasketValueDto?> LogisticFlows,
    List<BasketValueDto?> Coupons,
    List<BasketValueDto?> WarrantyCostOptions,
    List<BasketValueDto?> ShippingCostOptions);

public record FetchResourcesFailureAction(string ErrorMessage);