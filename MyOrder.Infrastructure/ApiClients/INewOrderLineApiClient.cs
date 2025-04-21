using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using Refit;
namespace MyOrder.Infrastructure.ApiClients;

public interface INewOrderLineApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/newLine")]
    Task<BasketLineDto?> GetNewLineAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
#warning This should return a ProcedureCallResponse
    [Put("/api/myorder/{companyId}/{basketId}/newLine/reset")]
    Task<BasketLineDto?> ResetNewLineStateAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Post("/api/myorder/{companyId}/{basketId}/newLine/add")]
    Task<ProcedureCallResponseDto?> CommitAddNewLineAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Post("/api/myorder/{companyId}/{basketId}/newLine/addFreeText")]
    Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(
        string companyId, 
        string basketId,
        [Body] List<string?> freeTexts,
        CancellationToken cancellationToken = default);
}