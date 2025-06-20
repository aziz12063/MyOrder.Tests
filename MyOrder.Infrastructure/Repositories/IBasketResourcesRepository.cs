using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IBasketResourcesRepository
{
      //==============================//
     //       Common resources       //
    //==============================//
    Task<List<BasketValueDto?>?> GetContactSalutationsAsync(CancellationToken cancellationToken = default);

    //==============================//
    //      Order resources         //
    //==============================//
    Task<List<BasketValueDto?>?> GetCustomerTagsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetSalesOriginsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetSalesPoolAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Delivery resources      //
    //==============================//
    Task<List<BasketValueDto?>?> GetDeliveryCountriesAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetCarrierTypesAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Invoice resources       //
    //==============================//
    Task<List<BasketValueDto?>?> GetTaxGroupsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetPaymentModesAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Prices resources        //
    //==============================//
    Task<List<BasketValueDto?>?> GetCouponsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Lines resources         //
    //==============================//
    Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(CancellationToken cancellationToken = default);
}