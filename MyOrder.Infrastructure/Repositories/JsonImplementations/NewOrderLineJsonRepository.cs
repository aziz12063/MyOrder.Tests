using Microsoft.Extensions.Logging;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class NewOrderLineJsonRepository(IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<OrderLinesJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), INewOrderLineRepository
{

    public async Task<BasketLineDto?> GetNewLineAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "newLine.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching new line for basketId {BasketId}", BasketId);
        var operationDescription = $"GetNewLineAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<BasketLineDto>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<BasketLineDto?> ResetNewLineStateAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Resetting new line state for basketId {BasketId}", BasketId);
        var operationDescription = $"ResetNewLineStateAsync for basketId {BasketId}";
        var result = new BasketLineDto();
        return await ExecuteAsync(
            (token) => {
                return Task.FromResult<BasketLineDto?>(result);
            },
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> CommitAddNewLineAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Committing add new line for basketId {BasketId}", BasketId);
        var operationDescription = $"CommitAddNewLineAsync for basketId {BasketId}";
        var result = new ProcedureCallResponseDto(
             UpdateDone: true,
     RefreshCalls: null,
     Target: null,
     Success: true,
     Message: "Add line committed successfully",
     ErrorCause: null
         );
        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult<ProcedureCallResponseDto?>(result);
            },
            operationDescription,
            cancellationToken);
    }
    public async Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(List<string?> freeTexts, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Committing add free text line for basketId {BasketId}", BasketId);
        var operationDescription = $"CommitAddFreeTextLineAsync for basketId {BasketId}";
        var result = new ProcedureCallResponseDto(UpdateDone: true,
     RefreshCalls: null,
     Target: null,
     Success: true,
     Message: "Add Free Text committed successfully",
     ErrorCause: null);
        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult<ProcedureCallResponseDto?>(result);
            },
            operationDescription,
            cancellationToken);
    }
}
