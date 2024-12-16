using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class InvoiceInfoRepository(IInvoiceInfoApiClient invoiceInfoApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<InvoiceInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IInvoiceInfoRepository
{
    private readonly IInvoiceInfoApiClient _invoiceInfoApiClient = invoiceInfoApiClient
        ?? throw new ArgumentNullException(nameof(invoiceInfoApiClient));

    public async Task<BasketInvoiceInfoDto?> GetBasketInvoiceInfoAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching invoice info for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketInvoiceInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _invoiceInfoApiClient.GetBasketInvoiceInfoAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching invoice to accounts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetInvoiceToAccountsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _invoiceInfoApiClient.GetInvoiceToAccountsAsync(BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }
}
