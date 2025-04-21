using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IBasketRessourcesRepository
{
      //==============================//
     //      Order ressources        //
    //==============================//
    Task<List<BasketValueDto?>?> GetCustomerTagsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetSalesOriginsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetSalesPoolAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Delivery ressources     //
    //==============================//

      //==============================//
     //      Invoice ressources      //
    //==============================//
    Task<List<BasketValueDto?>?> GetTaxGroupsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetPaymentModesAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Prices ressources       //
    //==============================//
    Task<List<BasketValueDto?>?> GetCouponsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(CancellationToken cancellationToken = default);

      //==============================//
     //      Lines ressources        //
    //==============================//
    Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(CancellationToken cancellationToken = default);
}