using MyOrder.Shared.Dtos;
using Refit;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketActionsApiClient
{
    [Post("/api/orderContext")]
    Task<NewBasketResponseDto?> CreateNewBasketAsync(
        [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string?> formFields, 
        CancellationToken cancellationToken = default);

    [Post("/api/orderContext/{basketId}/procedureCall")]
    Task<ProcedureCallResponseDto?> PostProcedureCallAsync(
        [Body] ImmutableList<string?> procedureCall,
        string basketId, 
        CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/reload")]
    Task<NewOrderContextResponse?> ReloadOrderContextAsync(string basketId, CancellationToken cancellationToken = default);
}