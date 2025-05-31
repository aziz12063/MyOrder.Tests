using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketRessourcesApiClient
{
      //==============================//
     //      Order ressources        //
    //==============================//
    [Get("/api/myorder/{companyId}/{basketId}/customerTags")]
    Task<List<BasketValueDto?>?> GetCustomerTagsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/salesOrigins")]
    Task<List<BasketValueDto?>?> GetSalesOriginsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/salesPools")]
    Task<List<BasketValueDto?>?> GetSalesPoolAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Delivery ressources     //
    //==============================//
    [Get("/api/myorder/{companyId}/{basketId}/countries")]
    Task<List<BasketValueDto?>?> GetDeliveryCountriesAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/carrierTypes")]
    Task<List<BasketValueDto?>?> GetCarrierTypesAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Invoice ressources      //
    //==============================//
    [Get("/api/myorder/{companyId}/{basketId}/taxGroups")]
    Task<List<BasketValueDto?>?> GetTaxGroupsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Prices ressources       //
    //==============================//
    [Get("/api/myorder/{companyId}/{basketId}/paymentModes")]
    Task<List<BasketValueDto?>?> GetPaymentModesAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
    [Get("/api/myorder/{companyId}/{basketId}/coupons")]
    Task<List<BasketValueDto?>?> GetCouponsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/warrantyCostOptions")]
    Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/shippingCostOptions")]
    Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

      //==============================//
     //      Lines ressources        //
    //==============================//
    [Get("/api/myorder/{companyId}/{basketId}/lineUpdateReasons")]
    Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/logisticFlows")]
    Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}
