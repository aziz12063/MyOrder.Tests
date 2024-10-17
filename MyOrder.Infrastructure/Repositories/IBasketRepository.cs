using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;
using Refit;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.Repositories;
public interface IBasketRepository
{
    Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);
    Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string basketId);

    //=======================================================================================================
    //Actions Section
    //=======================================================================================================
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(ImmutableList<string> readToPostProcedureCall, string basketId);
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(IField field, object value, string basketId);
    Task<NewBasketResponseDto> PostNewBasketAsync(Dictionary<string, string> newBasketRequest);
    Task<NewOrderContextResponse> ReloadOrderContextAsync(string basketId);

    //=======================================================================================================
    //Order Info Section
    //=======================================================================================================
    Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);
    Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId);
    Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId);
    Task<List<BasketValueDto?>> GetSalesOriginsAsync(string basketId);
    Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId);
    Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId);

    //=======================================================================================================
    //Delivery section
    //=======================================================================================================
    Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);
    Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId);
    Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId);
    Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId);

    //=======================================================================================================
    //Invoice info section
    //=======================================================================================================
    Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId);
    Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId);
    Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId);
    Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId);

    //=======================================================================================================
    // Trade Info Section
    //=======================================================================================================
    Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId);

    //=======================================================================================================
    //PriceLines info section
    //=======================================================================================================
    Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);
    Task<List<BasketValueDto?>> GetCouponsAsync(string basketId);
    Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId);
    Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId);



    //=======================================================================================================
    //Lines
    //=======================================================================================================
    Task<BasketOrderLinesDto> GetBasketLinesAsync(string basketId);
    Task<List<BasketValueDto?>> GetlineUpdateReasonsAsync(string basketId);
    Task<List<BasketValueDto?>> GetlogisticFlowsAsync(string basketId);
    Task<BasketLineDto?> GetNewLineAsync(string basketId);
    Task<BasketLineDto> ResetNewLineStateAsync(string basketId);
    Task<ProcedureCallResponseDto> CommitAddNewLineAsync(string basketId);
    Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(string basketId, string? filter = null);
}