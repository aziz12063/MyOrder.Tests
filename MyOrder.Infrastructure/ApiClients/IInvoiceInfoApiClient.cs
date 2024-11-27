using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IInvoiceInfoApiClient
{
    [Get("/api/orderContext/{basketId}/invoiceInfo")]
    Task<BasketInvoiceInfoDto?> GetBasketInvoiceInfoAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/invoiceToAccounts")]
    Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);
}
