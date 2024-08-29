using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using Refit;

namespace MyOrder.Infrastructure.Repositories;
public interface IBasketRepository
{
    Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

    //=======================================================================================================
    //Order Info Section
    //=======================================================================================================
    Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);
    Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId);
    Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId);
    Task<List<SalesOriginDto?>> GetSalesOriginsAsync(string basketId);
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
    //Prices info section
    //=======================================================================================================
    Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);
    Task<List<BasketValueDto?>> GetCouponsAsync(string basketId);
    Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId);
    Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId);

    //=======================================================================================================
    //Procedure Call
    //=======================================================================================================
    Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall);

    //=======================================================================================================
    //Lines
    //=======================================================================================================
    Task<BasketOrderLinesDto> GetBasketLinesAsync(string basketId);
    Task<List<BasketValueDto>> GetlineUpdateReasonsAsync(string basketId);
    Task<List<BasketValueDto>> GetlogisticFlowsAsync(string basketId);


    //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);

}
