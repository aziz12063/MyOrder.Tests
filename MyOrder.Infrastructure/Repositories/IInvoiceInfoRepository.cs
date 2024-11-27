using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IInvoiceInfoRepository
{
    Task<BasketInvoiceInfoDto?> GetBasketInvoiceInfoAsync(CancellationToken cancellationToken = default);
    Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(string? filter = null, CancellationToken cancellationToken = default);
}
