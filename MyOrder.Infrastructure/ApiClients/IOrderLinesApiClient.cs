using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IOrderLinesApiClient
{
    [Get("/api/orderContext/{basketId}/orderLines")]
    Task<BasketOrderLinesDto?> GetOrderLinesAsync(string basketId, CancellationToken cancellationToken = default);

    [Post("/api/orderContext/{basketId}/orderLines/duplicate")]
    Task<ProcedureCallResponseDto?> DuplicateOrderLinesAsync(
        string basketId,
        [Body] List<int> linesIds,
        CancellationToken cancellationToken = default);

    [Post("/api/orderContext/{basketId}/orderLines/delete")]
    Task<ProcedureCallResponseDto?> DeleteOrderLinesAsync(
        string basketId,
        [Body] List<int> linesIds,
        CancellationToken cancellationToken = default);
}