using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IInvoiceInfoApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/invoiceInfo")]
    Task<InvoicePanelDto?> GetBasketInvoiceInfoAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/invoiceToAccounts")]
    Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(
        string companyId,
        string basketId,
        [Query] string? filter = null,
        [Query] bool? search = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/PaymentAuthorization")]
    Task<PaymentAuthorizationDto> GetPaymentAuthorizationAsync(
        string companyId,
        string basketId,
        CancellationToken cancellationToken = default);
}
