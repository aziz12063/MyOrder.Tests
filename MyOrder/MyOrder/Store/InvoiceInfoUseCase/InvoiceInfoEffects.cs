using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos.Invoice;

namespace MyOrder.Store.InvoiceInfoUseCase;

public class InvoiceInfoEffects(IInvoiceInfoRepository invoiceInfoRepository, ILogger<InvoiceInfoEffects> logger)
{
    private readonly IInvoiceInfoRepository _invoiceInfoRepository = invoiceInfoRepository
        ?? throw new ArgumentNullException(nameof(invoiceInfoRepository));

    [EffectMethod]
    public async Task HandleFetchInvoiceInfoAction(FetchInvoiceInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var invoiceInfo = await _invoiceInfoRepository.GetBasketInvoiceInfoAsync();

            dispatcher.Dispatch(new FetchInvoiceInfoSuccessAction(invoiceInfo));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while fetching invoice info");
            dispatcher.Dispatch(new FetchInvoiceInfoFailureAction(e.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchInvoiceInfoAccountsAction(FetchInvoiceAccountsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isSearch = action.IsSearch ?? false;
            logger.LogInformation("Fetching invoice info accounts.");
            var accountList = await _invoiceInfoRepository.GetInvoiceToAccountsAsync(action.Filter, action.IsSearch);
            dispatcher.Dispatch(new FetchInvoiceAccountsSuccessAction(accountList, isSearch));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching invoice info accounts data");
            dispatcher.Dispatch(new FetchInvoiceAccountsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchPaymentAuthorizationAction(FetchPaymentAuthorizationAction action, IDispatcher dispatcher)
    {
        try
        {
            var paymentAuthorization = await _invoiceInfoRepository.GetPaymentAuthorizationAsync();

            if (paymentAuthorization is null)
                dispatcher.Dispatch(new FetchPaymentAuthorizationFailureAction($"Server returned null for {nameof(PaymentAuthorizationDto)}."));
            else
                dispatcher.Dispatch(new FetchPaymentAuthorizationSuccessAction(paymentAuthorization));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching payment authorization data");
            dispatcher.Dispatch(new FetchPaymentAuthorizationFailureAction(ex.Message));
        }
    }
}

