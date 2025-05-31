using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Infrastructure.Repositories;

public interface IOrderLinesRepository
{
    Task<BasketOrderLinesDto?> GetOrderLinesAsync(CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> DuplicateOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> DeleteOrderLinesAsync(List<int> linesIds, CancellationToken cancellationToken = default);
    Task<List<Supplier>?> GetSuppliersAsync(bool search = true, string? filter = null, CancellationToken cancellationToken = default);
}