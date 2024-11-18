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
            var invoiceInfo = await basketRepository.GetBasketInvoiceInfoAsync(action.BasketId);

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
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            logger.LogInformation("Fetching invoice info accounts for {BasketId}", action.BasketId);
            var accountList = await basketRepository.GetInvoiceToAccountsAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchInvoiceAccountsSuccessAction(accountList, isFiltered));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching invoice info accounts data");
            dispatcher.Dispatch(new FetchInvoiceAccountsFailureAction(ex.Message));
        }
    }
}

