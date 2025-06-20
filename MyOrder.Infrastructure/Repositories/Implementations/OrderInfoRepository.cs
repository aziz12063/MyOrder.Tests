using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class OrderInfoRepository(IOrderInfoApiClient orderInfoApiClient,
    IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<OrderInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IOrderInfoRepository
{
    private readonly IOrderInfoApiClient _orderInfoApiClient = orderInfoApiClient
        ?? throw new ArgumentNullException(nameof(orderInfoApiClient));

    public async Task<BasketOrderInfoDto?> GetBasketOrderInfoAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching orderinfo for {BasketId} from repository", BasketId);
        var operationDescription = $"GetOrderInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _orderInfoApiClient.GetBasketOrderInfoAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public Task<List<ContactDto?>?> GetOrderByContactsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching order by contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetOrderByContactsAsync for basketId {BasketId}";
        return ExecuteAsync(
            async (token) => await _orderInfoApiClient.GetOrderByContactsAsync(CompanyId, BasketId, filter, search, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetWebOriginsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching web origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWebOriginsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _orderInfoApiClient.GetWebOriginsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
}
