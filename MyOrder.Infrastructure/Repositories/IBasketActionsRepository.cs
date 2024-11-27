using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.Repositories;

public interface IBasketActionsRepository
{
    Task<NewBasketResponseDto?> PostNewBasketAsync(Dictionary<string, string?> newBasketRequest, CancellationToken cancellationToken = default);
    Task<NewOrderContextResponse?> ReloadOrderContextAsync(CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(ImmutableList<string?> readToPostProcedureCall, CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(IField field, object value, CancellationToken cancellationToken = default);
}