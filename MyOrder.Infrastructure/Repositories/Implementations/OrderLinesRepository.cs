using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class OrderLinesRepository(IOrderLinesApiClient basketLinesApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<OrderLinesRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IOrderLinesRepository
{
    private readonly IOrderLinesApiClient _basketLinesApiClient = basketLinesApiClient
        ?? throw new ArgumentNullException(nameof(basketLinesApiClient));

    public async Task<BasketOrderLinesDto?> GetOrderLinesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket lines for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketLinesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketLinesApiClient.GetOrderLinesAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> DuplicateOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Duplicating order lines for basketId {BasketId}", BasketId);
        var operationDescription = $"DuplicateOrderLinesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketLinesApiClient.DuplicateOrderLinesAsync(BasketId, linesIds, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> DeleteOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Deleting order lines for basketId {BasketId}", BasketId);
        var operationDescription = $"DeleteOrderLinesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketLinesApiClient.DeleteOrderLinesAsync(BasketId, linesIds, token),
            operationDescription,
            cancellationToken);
    }
}