using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface INewOrderLineRepository
{
    Task<BasketLineDto?> GetNewLineAsync(CancellationToken cancellationToken = default);
    Task<BasketLineDto?> ResetNewLineStateAsync(CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> CommitAddNewLineAsync(CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(List<string?> freeTexts, CancellationToken cancellationToken = default);
}