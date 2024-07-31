using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Infrastructure.Repositories;

public class BasketRepository(IBasketApiClient apiClient, ILogger<BasketRepository> logger)
    : IBasketRepository
{

    public async Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket general info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketGeneralInfoAsync(basketId);
    }

    public async Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket order info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketOrderInfoAsync(basketId);
    }

    public async Task<List<SalesOriginDto>> GetSalesOriginsAsync(string basketId)
    {
        logger.LogInformation("Fetching SalesOrigins info for {BasketId} from repository", basketId);
        return await apiClient.GetSalesOriginsAsync(basketId);
    }

    public async Task<List<SalesPoolsDto>> GetSalesPoolAsync(string basketId)
    {
        logger.LogInformation("Fetching SalesPools info for {BasketId} from repository", basketId);
        return await apiClient.GetSalesPoolsAsync(basketId);
    }

    public async Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
    {  
        logger.LogInformation("Fetching basket prices info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketPricesInfoAsync(basketId);
    }

    public async Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
    {
        logger.LogInformation("Fetching basket delivery info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketDeliveryInfoAsync(basketId);
    }

    public async Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall)
    {
        logger.LogInformation("Posting procedure call : \n{procedureCall} \nfor {BasketId} to repository", string.Join("\n", procedureCall), basketId);
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
