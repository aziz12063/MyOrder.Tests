using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos.Lines;
using Refit;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketApiClient
{
    //=======================================================================================================
    // Actions Section
    //=======================================================================================================
    [Post("/api/orderContext")]
    Task<NewBasketResponseDto> CreateNewBasketAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> formFields);

    [Post("/api/orderContext/{basketId}/procedureCall")]
    Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, [Body] ImmutableList<string?> procedureCall);

    [Get("/api/orderContext/{basketId}/reload")]
    Task<NewOrderContextResponse> ReloadOrderContextAsync(string basketId);

    //=======================================================================================================
    // General Info Section
    //=======================================================================================================
    #region General Info
    [Get("/api/orderContext/{basketId}/generalInfo")]
    Task<GeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

    [Get("/api/orderContext/{basketId}/notifications")]
    Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/blockingReasons")]
    Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/validationRules")]
    Task<List<BasketNotificationDto?>?> GetValudationRulesAsync(string basketId);
    #endregion

    //=======================================================================================================
    // Order Info Section
    //=======================================================================================================
    #region OrderInfo
    [Get("/api/orderContext/{basketId}/orderInfo")]
    Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);

    [Get("/api/orderContext/{basketId}/orderByContacts")]
    Task<List<ContactDto?>> GetOrderByContactsAsync(
        string basketId,
        [Query] string? filter = null);

    [Get("/api/orderContext/{basketId}/customerTags")]
    Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/salesOrigins")]
    Task<List<BasketValueDto?>> GetSalesOriginsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/webOrigins")]
    Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/salesPools")]
    Task<List<BasketValueDto?>> GetSalesPoolsAsync(string basketId);
    #endregion
    //=======================================================================================================
    // Delivery Info Section
    //=======================================================================================================
    #region Delivery Info
    [Get("/api/orderContext/{basketId}/deliveryInfo")]
    Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);

    [Get("/api/orderContext/{basketId}/deliverToAccounts")]
    Task<List<AccountDto?>> GetDeliverToAccountsAsync(
        string basketId,
        [Query] string? filter = null);

    [Get("/api/orderContext/{basketId}/deliverToContacts")]
    Task<List<ContactDto?>> GetDeliverToContactsAsync(
        string basketId,
        [Query] string? filter = null);

    [Get("/api/orderContext/{basketId}/deliveryModes")]
    Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId);
    #endregion

    //=======================================================================================================
    // Invoice Info Section
    //=======================================================================================================
    #region Invoice Info
    [Get("/api/orderContext/{basketId}/invoiceInfo")]
    Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId);

    [Get("/api/orderContext/{basketId}/invoiceToAccounts")]
    Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/taxGroups")]
    Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/paymentModes")]
    Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId);
    #endregion

    //=======================================================================================================
    // Trade Info Section
    //=======================================================================================================
    #region Trade Info
    [Get("/api/orderContext/{basketId}/tradeInfo")]
    Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId);
    #endregion

    //=======================================================================================================
    // PriceLines Info Section
    //=======================================================================================================
    #region Prices Info
    [Get("/api/orderContext/{basketId}/pricesInfo")]
    Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);

    [Get("/api/orderContext/{basketId}/coupons")]
    Task<List<BasketValueDto?>> GetCouponsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/warrantyCostOptions")]
    Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/shippingCostOptions")]
    Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId);
    #endregion

    //=======================================================================================================
    //Lines Section
    //=======================================================================================================
    #region Lines
    [Get("/api/orderContext/{basketId}/orderLines")]
    Task<BasketOrderLinesDto> GetBasketLinesAsync(string basketId);

    [Get("/api/orderContext/{basketId}/lineUpdateReasons")]
    Task<List<BasketValueDto?>> GetlineUpdateReasonsAsync(string basketId);

    [Get("/api/orderContext/{basketId}/logisticFlows")]
    Task<List<BasketValueDto?>> GetlogisticFlowsAsync(string basketId);

    [Post("/api/orderContext/{basketId}/orderLines/duplicate")]
    Task<ProcedureCallResponseDto> DuplicateOrderLinesAsync(
        string basketId,
        [Body] List<int> linesIds);

    [Post("/api/orderContext/{basketId}/orderLines/delete")]
    Task<ProcedureCallResponseDto> DeleteOrderLinesAsync(
        string basketId,
        [Body] List<int> linesIds);

    [Get("/api/orderContext/{basketId}/newLine")]
    Task<BasketLineDto?> GetNewLineAsync(string basketId);

    [Put("/api/orderContext/{basketId}/newLine/reset")]
    Task<BasketLineDto> ResetNewLineStateAsync(string basketId);

    [Post("/api/orderContext/{basketId}/newLine/add")]
    Task<ProcedureCallResponseDto> CommitAddNewLineAsync(string basketId);

    [Post("/api/orderContext/{basketId}/newLine/addFreeText")]
    Task<ProcedureCallResponseDto> CommitAddFreeTextLineAsync(
        string basketId,
        [Body] List<string?> freeTexts);

    [Get("/api/orderContext/{basketId}/bestSellerItems")]
    Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(
        string basketId,
        [Query] string? filter = null);

    [Get("/api/orderContext/{basketId}/orderedItems")]
    Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(
        string basketId,
        [Query] string? filter = null);

    [Get("/api/orderContext/{basketId}/searchItems")]
    Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(
       string basketId,
       [Query] string? filter = null);
    #endregion


}
