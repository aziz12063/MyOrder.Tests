using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class InvoiceInfoJsonRepository( IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<InvoiceInfoJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IInvoiceInfoRepository
{
    

    public async Task<InvoicePanelDto?> GetBasketInvoiceInfoAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "invoiceInfo.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching invoice info for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketInvoiceInfoAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<InvoicePanelDto>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<AccountDto?>?> GetInvoiceToAccountsAsync(string? filter = null, bool? isSearch = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "invoiceToAccounts.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching invoice to accounts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetInvoiceToAccountsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<AccountDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<PaymentAuthorizationDto?> GetPaymentAuthorizationAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching payment authorization for {BasketId} from repository", BasketId);

        var sendpayementLinkMod = new Field<SendPaymentLinkMode?>(null, SendPaymentLinkMode.Email, null,
                                                                  null, null, null, null, null, null, null, null);

        var paymentAuthorizationDto = new PaymentAuthorizationDto(ContactName: null,
                                                              SendPaymentLinkMode: sendpayementLinkMod,
                                                              ContactPhone: null, ContactEmail: null,
                                                              SalesId: null, AuthorizationNumber: null, AuthorizationAmount: null,
                                                              AuthorizationDate: null, AuthorizationStatus: null,
                                                              Actions: null, PanelLabel: null, HasOngoingAuthorization: true);

        return paymentAuthorizationDto;
    }
}
