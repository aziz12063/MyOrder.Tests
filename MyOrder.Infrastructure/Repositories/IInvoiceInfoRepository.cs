using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;

namespace MyOrder.Infrastructure.Repositories;

public interface IInvoiceInfoRepository
{
    Task<InvoicePanelDto?> GetBasketInvoiceInfoAsync(CancellationToken cancellationToken = default);
    Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(
        string? filter = null,
        bool? isSearch = null,
        CancellationToken cancellationToken = default);
    Task<PaymentAuthorizationDto?> GetPaymentAuthorizationAsync(CancellationToken cancellationToken = default);
}
