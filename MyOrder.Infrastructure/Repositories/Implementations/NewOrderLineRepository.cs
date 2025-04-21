using Microsoft.Extensions.Logging;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class NewOrderLineRepository(INewOrderLineApiClient newOrderLineApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<OrderLinesRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), INewOrderLineRepository
{
    private readonly INewOrderLineApiClient _newOrderLineApiClient = newOrderLineApiClient

    ?? throw new ArgumentNullException(nameof(newOrderLineApiClient));

    public async Task<BasketLineDto?> GetNewLineAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching new line for basketId {BasketId}", BasketId);
        var operationDescription = $"GetNewLineAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _newOrderLineApiClient.GetNewLineAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<BasketLineDto?> ResetNewLineStateAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Resetting new line state for basketId {BasketId}", BasketId);
        var operationDescription = $"ResetNewLineStateAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _newOrderLineApiClient.ResetNewLineStateAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> CommitAddNewLineAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Committing add new line for basketId {BasketId}", BasketId);
        var operationDescription = $"CommitAddNewLineAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _newOrderLineApiClient.CommitAddNewLineAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
    public async Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(List<string?> freeTexts, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Committing add free text line for basketId {BasketId}", BasketId);
        var operationDescription = $"CommitAddFreeTextLineAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _newOrderLineApiClient.CommitAddFreeTextLineAsync(CompanyId, BasketId, freeTexts, token),
            operationDescription,
            cancellationToken);
    }
}
