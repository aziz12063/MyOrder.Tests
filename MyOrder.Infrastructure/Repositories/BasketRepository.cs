using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public class BasketRepository(IBasketApiClient apiClient, ILogger<BasketRepository> logger)
    : IBasketRepository
{

    public async Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket general info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketGeneralInfoAsync(basketId);
    }

    //=======================================================================================================
    //Order Info Section
    //=======================================================================================================
    public async Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket order info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketOrderInfoAsync(basketId);
    }

    public async Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId)
    {
        logger.LogInformation("Fetching order by contacts for {BasketId} from repository", basketId);
        return await apiClient.GetOrderByContactsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId)
    {
        logger.LogInformation("Fetching customer tags for {BasketId} from repository", basketId);
        return await apiClient.GetCustomerTagsAsync(basketId);
    }

    public async Task<List<SalesOriginDto?>> GetSalesOriginsAsync(string basketId)
    {
        logger.LogInformation("Fetching SalesOrigins info for {BasketId} from repository", basketId);
        return await apiClient.GetSalesOriginsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId)
    {
        logger.LogInformation("Fetching WebOrigins info for {BasketId} from repository", basketId);
        return await apiClient.GetWebOriginsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId)
    {
        logger.LogInformation("Fetching SalesPools info for {BasketId} from repository", basketId);
        return await apiClient.GetSalesPoolsAsync(basketId);
    }

    //=======================================================================================================
    //Delivery section
    //=======================================================================================================
    public async Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket delivery info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketDeliveryInfoAsync(basketId);
    }

    public async Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId)
    {
        logger.LogInformation("Fetching deliver to accounts for {BasketId} from repository", basketId);
        return await apiClient.GetDeliverToAccountsAsync(basketId);
    }

    public async Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId)
    {
        logger.LogInformation("Fetching deliver to contacts for {BasketId} from repository", basketId);
        return await apiClient.GetDeliverToContactsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId)
    {
        logger.LogInformation("Fetching delivery modes for {BasketId} from repository", basketId);
        return await apiClient.GetDeliveryModesAsync(basketId);
    }

    //=======================================================================================================
    //Invoice info section
    //=======================================================================================================
    public async Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket invoice info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketInvoiceInfoAsync(basketId);
    }

    public async Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId)
    {
        logger.LogInformation("Fetching invoice to accounts for {BasketId} from repository", basketId);
        return await apiClient.GetInvoiceToAccountsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId)
    {
        logger.LogInformation("Fetching tax groups for {BasketId} from repository", basketId);
        return await apiClient.GetTaxGroupsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId)
    {
        logger.LogInformation("Fetching payment modes for {BasketId} from repository", basketId);
        return await apiClient.GetPaymentModesAsync(basketId);
    }

    //=======================================================================================================
    // Trade Info Section
    //=======================================================================================================
    public async Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket trade info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketTradeInfoAsync(basketId);
    }

    //=======================================================================================================
    //Prices info section
    //=======================================================================================================
    public async Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket prices info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketPricesInfoAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetCouponsAsync(string basketId)
    {
        logger.LogInformation("Fetching coupons for {BasketId} from repository", basketId);
        return await apiClient.GetCouponsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId)
    {
        logger.LogInformation("Fetching warranty cost options for {BasketId} from repository", basketId);
        return await apiClient.GetWarrantyCostOptionsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId)
    {
        logger.LogInformation("Fetching shipping cost options for {BasketId} from repository", basketId);
        return await apiClient.GetShippingCostOptionsAsync(basketId);
    }

    //=======================================================================================================
    //Procedure Call
    //=======================================================================================================
    public async Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall)
    {
        logger.LogInformation("Posting procedure call : \n{procedureCall} \nfor {BasketId} from repository", string.Join("\n", procedureCall), basketId);
        return await apiClient.PostProcedureCallAsync(basketId, procedureCall);
    }

    /*
    public async Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId)
    {
        _logger.LogInformation("Fetching notifications for {BasketId} from repository", basketId);
        return await _apiClient.GetNotificationsAsync(basketId);
    }

    public async Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId)
    {
        _logger.LogInformation("Fetching basket lines for {BasketId} from repository", basketId);
        return await _apiClient.GetBasketLinesAsync(basketId);
    }
    */
}
