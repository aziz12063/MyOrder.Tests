using MyOrder.Shared.Dtos;
using Refit;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketActionsApiClient
{
    [Post("/api/myorder/{companyId}")]
    Task<NewBasketResponseDto?> CreateNewBasketAsync(
        string companyId,
        [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string?> formFields, 
        CancellationToken cancellationToken = default);

    [Post("/api/myorder/{companyId}/{basketId}/procedureCall")]
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(
        [Body] ImmutableList<string?> procedureCall,
        string companyId,
        string basketId, 
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/reload")]
    Task<NewOrderContextResponse?> ReloadOrderContextAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}