using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients
{
    public interface IBasketApiClient
    {

        [Get("/api/orderContext/{basketId}/generalInfo")]
        Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

        //=======================================================================================================
        // Order Info Section
        //=======================================================================================================
        [Get("/api/orderContext/{basketId}/orderInfo")]
        Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/orderByContacts")]
        Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/customerTags")]
        Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/salesOrigins")]
        Task<List<SalesOriginDto?>> GetSalesOriginsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/webOrigins")]
        Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/salesPools")]
        Task<List<BasketValueDto?>> GetSalesPoolsAsync(string basketId);

        //=======================================================================================================
        // Delivery Info Section
        //=======================================================================================================
        [Get("/api/orderContext/{basketId}/deliveryInfo")]
        Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/deliverToAccounts")]
        Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/deliverToContacts")]
        Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/deliveryModes")]
        Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId);

        //=======================================================================================================
        // Invoice Info Section
        //=======================================================================================================
        [Get("/api/orderContext/{basketId}/invoiceInfo")]
        Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/invoiceToAccounts")]
        Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/taxGroups")]
        Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/paymentModes")]
        Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId);

        //=======================================================================================================
        // Trade Info Section
        //=======================================================================================================
        [Get("/api/orderContext/{basketId}/tradeInfo")]
        Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId);

        //=======================================================================================================
        // Prices Info Section
        //=======================================================================================================
        [Get("/api/orderContext/{basketId}/pricesInfo")]
        Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/coupons")]
        Task<List<BasketValueDto?>> GetCouponsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/warrantyCostOptions")]
        Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/shippingCostOptions")]
        Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId);

        //=======================================================================================================
        // Procedure Call Section
        //=======================================================================================================
        [Post("/api/orderContext/{basketId}/procedureCall")]
        Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, [Body] List<string> procedureCall);

        //[Get("/api/orderContext/{basketId}/notifications")]
        //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);

        //[Get("/api/orderContext/{basketId}/lines")]
        //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
    }
}
