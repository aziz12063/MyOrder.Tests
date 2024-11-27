using Fluxor;
using MyOrder.Infrastructure.Repositories;

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
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            logger.LogInformation("Fetching invoice info accounts for {BasketId}", action.BasketId);
            var accountList = await _invoiceInfoRepository.GetInvoiceToAccountsAsync(action.Filter);
            dispatcher.Dispatch(new FetchInvoiceAccountsSuccessAction(accountList, isFiltered));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching invoice info accounts data");
            dispatcher.Dispatch(new FetchInvoiceAccountsFailureAction(ex.Message));
        }
    }
}

