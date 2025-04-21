using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IOrderLinesApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/orderLines")]
    Task<BasketOrderLinesDto?> GetOrderLinesAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Post("/api/myorder/{companyId}/{basketId}/orderLines/duplicate")]
    Task<ProcedureCallResponseDto?> DuplicateOrderLinesAsync(
        string companyId,
        string basketId,
        [Body] List<int> linesIds,
        CancellationToken cancellationToken = default);

    [Post("/api/myorder/{companyId}/{basketId}/orderLines/delete")]
    Task<ProcedureCallResponseDto?> DeleteOrderLinesAsync(
        string companyId,
        string basketId,
        [Body] List<int> linesIds,
        CancellationToken cancellationToken = default);
}