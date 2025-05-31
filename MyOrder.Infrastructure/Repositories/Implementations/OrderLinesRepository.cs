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
            async (token) => await _basketLinesApiClient.GetOrderLinesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> DuplicateOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Duplicating order lines for basketId {BasketId}", BasketId);
        var operationDescription = $"DuplicateOrderLinesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketLinesApiClient.DuplicateOrderLinesAsync(CompanyId, BasketId, linesIds, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> DeleteOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Deleting order lines for basketId {BasketId}", BasketId);
        var operationDescription = $"DeleteOrderLinesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketLinesApiClient.DeleteOrderLinesAsync(CompanyId, BasketId, linesIds, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<Supplier>?> GetSuppliersAsync(bool search = true, string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching suppliers for basketId {BasketId}", BasketId);
        var operationDescription = $"GetSuppliersAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketLinesApiClient.GetSuppliersAsync(CompanyId, BasketId, search, filter, token),
            operationDescription,
            cancellationToken);
    }
}