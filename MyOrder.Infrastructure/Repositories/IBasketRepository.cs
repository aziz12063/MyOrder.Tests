using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.Repositories;
public interface IBasketRepository
{
    //=======================================================================================================
    //Actions Section
    //=======================================================================================================
    #region Actions
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(ImmutableList<string> readToPostProcedureCall, string basketId);
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(IField field, object value, string basketId);
    Task<NewBasketResponseDto> PostNewBasketAsync(Dictionary<string, string> newBasketRequest);
    Task<NewOrderContextResponse> ReloadOrderContextAsync(string basketId);
    #endregion

    //=======================================================================================================
    // General Info Section
    //=======================================================================================================
    #region General Info
    Task<GeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);
    Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string basketId);
    Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(string basketId);
    Task<List<BasketNotificationDto?>?> GetValudationRulesAsync(string basketId);
    #endregion

    //=======================================================================================================
    //Order Info Section
    //=======================================================================================================
    #region Order Info
    Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);
    Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId, string? filter = null);
    Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId);
    Task<List<BasketValueDto?>> GetSalesOriginsAsync(string basketId);
    Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId);
    Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId);
    #endregion

    //=======================================================================================================
    //Delivery section
    //=======================================================================================================
    #region Delivery
    Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);
    Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId, string? filter = null);
    Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId, string? filter = null);
    Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId);
    #endregion

    //=======================================================================================================
    //Invoice info section
    //=======================================================================================================
    #region Invoice Info
    Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId);
    Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId, string? filter = null);
    Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId);
    Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId);
    #endregion

    //=======================================================================================================
    // Trade Info Section
    //=======================================================================================================
    Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId);

    //=======================================================================================================
    //PriceLines info section
    //=======================================================================================================
    #region PriceLines
    Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);
    Task<List<BasketValueDto?>> GetCouponsAsync(string basketId);
    Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId);
    Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId);
    #endregion


    //=======================================================================================================
    //Lines
    //=======================================================================================================
    #region Lines
    Task<BasketOrderLinesDto> GetBasketLinesAsync(string basketId);
    Task<List<BasketValueDto?>> GetlineUpdateReasonsAsync(string basketId);
    Task<List<BasketValueDto?>> GetlogisticFlowsAsync(string basketId);
    Task<ProcedureCallResponseDto> DuplicateOrderLinesAsync(string basketId, List<int> linesIds);
    Task<ProcedureCallResponseDto> DeleteOrderLinesAsync(string basketId, List<int> linesIds);
    Task<BasketLineDto?> GetNewLineAsync(string basketId);
    Task<BasketLineDto> ResetNewLineStateAsync(string basketId);
    Task<ProcedureCallResponseDto> CommitAddNewLineAsync(string basketId);
    Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(string basketId, List<string?> freeTexts);
    Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(string basketId, string? filter = null);
    Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(string basketId, string? filter = null);
    Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(string basketId, string? filter = null);
    #endregion
}