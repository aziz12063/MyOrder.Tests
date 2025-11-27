using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class OrderLinesJsonRepository(IOrderLinesApiClient basketLinesApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<OrderLinesJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IOrderLinesRepository
{

    public async Task<BasketOrderLinesDto?> GetOrderLinesAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "orderLines.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket lines for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketLinesAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<BasketOrderLinesDto>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> DuplicateOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Duplicating order lines for basketId {BasketId}", BasketId);
        var operationDescription = $"DuplicateOrderLinesAsync for basketId {BasketId}";
        var result = new ProcedureCallResponseDto(true, null, null, null, null, null);
        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult<ProcedureCallResponseDto?>(result);
            },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<Supplier>?> GetSuppliersAsync(bool search = true, string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "suppliers.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching suppliers for basketId {BasketId}", BasketId);
        var operationDescription = $"GetSuppliersAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<Supplier>?>(json));
             },
            operationDescription,
            cancellationToken);
    }
    public async Task<ProcedureCallResponseDto?> DeleteOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Deleting order lines for basketId {BasketId}", BasketId);
        var operationDescription = $"DeleteOrderLinesAsync for basketId {BasketId}";
        var result = new ProcedureCallResponseDto(true, null, null, null, null, null);
        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult<ProcedureCallResponseDto?>(result);
            },
            operationDescription,
            cancellationToken);
    }
}