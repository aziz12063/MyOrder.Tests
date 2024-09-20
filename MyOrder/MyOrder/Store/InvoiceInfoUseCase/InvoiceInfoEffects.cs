using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.InvoiceInfoUseCase;

public class InvoiceInfoEffects(IBasketRepository basketRepository, ILogger<InvoiceInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchInvoiceInfoAction(FetchInvoiceInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var invoiceInfo = basketRepository.GetBasketInvoiceInfoAsync(action.BasketId);
            var invoiceToAccounts = basketRepository.GetInvoiceToAccountsAsync(action.BasketId);

            await Task.WhenAll(invoiceInfo, invoiceToAccounts);

            dispatcher.Dispatch(new FetchInvoiceInfoSuccessAction(invoiceInfo.Result, invoiceToAccounts.Result));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while fetching invoice info");
            dispatcher.Dispatch(new FetchInvoiceInfoFailureAction(e.Message));
        }
    }
}

