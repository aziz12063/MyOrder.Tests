using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using Refit;
namespace MyOrder.Infrastructure.ApiClients;

public interface INewOrderLineApiClient
{
    [Get("/api/orderContext/{basketId}/newLine")]
    Task<BasketLineDto?> GetNewLineAsync(string basketId, CancellationToken cancellationToken = default);

    [Put("/api/orderContext/{basketId}/newLine/reset")]
    Task<BasketLineDto?> ResetNewLineStateAsync(string basketId, CancellationToken cancellationToken = default);

    [Post("/api/orderContext/{basketId}/newLine/add")]
    Task<ProcedureCallResponseDto?> CommitAddNewLineAsync(string basketId, CancellationToken cancellationToken = default);

    [Post("/api/orderContext/{basketId}/newLine/addFreeText")]
    Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(
        string basketId,
        [Body] List<string?> freeTexts,
        CancellationToken cancellationToken = default);
}