using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class InvoiceInfoRepository(IInvoiceInfoApiClient invoiceInfoApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<InvoiceInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IInvoiceInfoRepository
{
    private readonly IInvoiceInfoApiClient _invoiceInfoApiClient = invoiceInfoApiClient
        ?? throw new ArgumentNullException(nameof(invoiceInfoApiClient));

    public async Task<InvoicePanelDto?> GetBasketInvoiceInfoAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching invoice info for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketInvoiceInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _invoiceInfoApiClient.GetBasketInvoiceInfoAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(string? filter = null, bool? isSearch = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching invoice to accounts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetInvoiceToAccountsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _invoiceInfoApiClient.GetInvoiceToAccountsAsync(CompanyId, BasketId, filter, isSearch, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<PaymentAuthorizationDto?> GetPaymentAuthorizationAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching payment authorization for {BasketId} from repository", BasketId);
        var operationDescription = $"GetPaymentAuthorizationAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _invoiceInfoApiClient.GetPaymentAuthorizationAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
}
