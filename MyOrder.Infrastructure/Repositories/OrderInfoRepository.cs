using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories;

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
            async (token) => await _orderInfoApiClient.GetBasketOrderInfoAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public Task<List<ContactDto?>?> GetOrderByContactsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching order by contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetOrderByContactsAsync for basketId {BasketId}";
        return ExecuteAsync(
            async (token) => await _orderInfoApiClient.GetOrderByContactsAsync(BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }
}
