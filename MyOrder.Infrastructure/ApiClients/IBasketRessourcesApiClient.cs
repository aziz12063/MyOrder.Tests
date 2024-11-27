using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketRessourcesApiClient
{
      //==============================//
     //      Order ressources        //
    //==============================//
    [Get("/api/orderContext/{basketId}/customerTags")]
    Task<List<BasketValueDto?>?> GetCustomerTagsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/salesOrigins")]
    Task<List<BasketValueDto?>?> GetSalesOriginsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/webOrigins")]
    Task<List<BasketValueDto?>?> GetWebOriginsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/salesPools")]
    Task<List<BasketValueDto?>?> GetSalesPoolAsync(string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Delivery ressources     //
    //==============================//
    [Get("/api/orderContext/{basketId}/deliveryModes")]
    Task<List<BasketValueDto?>?> GetDeliveryModesAsync(string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Invoice ressources      //
    //==============================//
    [Get("/api/orderContext/{basketId}/taxGroups")]
    Task<List<BasketValueDto?>?> GetTaxGroupsAsync(string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Prices ressources       //
    //==============================//
    [Get("/api/orderContext/{basketId}/paymentModes")]
    Task<List<BasketValueDto?>?> GetPaymentModesAsync(string basketId, CancellationToken cancellationToken = default);
    [Get("/api/orderContext/{basketId}/coupons")]
    Task<List<BasketValueDto?>?> GetCouponsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/warrantyCostOptions")]
    Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/shippingCostOptions")]
    Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Lines ressources        //
    //==============================//
    [Get("/api/orderContext/{basketId}/lineUpdateReasons")]
    Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/logisticFlows")]
    Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(string basketId, CancellationToken cancellationToken = default);
}
