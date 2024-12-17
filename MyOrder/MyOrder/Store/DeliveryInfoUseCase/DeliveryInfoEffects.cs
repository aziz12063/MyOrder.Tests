using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class DeliveryInfoEffects(IDeliveryInfoRepository deliveryInfoRepository,
    IStateResolver stateResolver, ILogger<DeliveryInfoEffects> logger)
{
    private readonly IDeliveryInfoRepository _deliveryInfoRepo = deliveryInfoRepository 
        ?? throw new ArgumentNullException(nameof(deliveryInfoRepository));
    private readonly ILogger<DeliveryInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    private readonly IStateResolver _stateResolver = stateResolver
        ?? throw new ArgumentNullException(nameof(stateResolver));

    [EffectMethod]
    public async Task HandleFetchDeliveryInfoAction(FetchDeliveryInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var basketDeliveryInfo = await _deliveryInfoRepo.GetBasketDeliveryInfoAsync();
            dispatcher.Dispatch(new FetchDeliveryInfoSuccessAction(basketDeliveryInfo));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching delivery info");
            dispatcher.Dispatch(new FetchDeliveryInfoFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchDeliveryAccountsAction(FetchDeliveryAccountsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            _logger.LogInformation("Fetching delivery accounts for {BasketId}", action.BasketId);
            var accountList = await _deliveryInfoRepo.GetDeliverToAccountsAsync(action.Filter);
            dispatcher.Dispatch(new FetchDeliveryAccountsSuccessAction(accountList, isFiltered));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching delivery accounts data");
            dispatcher.Dispatch(new FetchDeliveryAccountsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchNewDeliveryAccountAction(FetchNewDeliveryAccountAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Fetching new delivery account");
            var deliveryAccountDraft = await _deliveryInfoRepo.GetNewDeliveryAccountAsync(action.AccountId);
            dispatcher.Dispatch(new FetchNewDeliveryAccountSuccessAction(deliveryAccountDraft));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching new delivery account data");
            dispatcher.Dispatch(new FetchNewDeliveryAccountFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleCommitNewDeliveryAccountAction(CommitNewDeliveryAccountAction action, IDispatcher dispatcher)
    {
        string errorMessage = "Fatal. Couldn't commit new line.";
        bool success = false;
        try
        {
            _logger.LogInformation("Committing new delivery account");
            var response = await _deliveryInfoRepo.CommitNewDeliveryAccountAsync();
            if (response?.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    _stateResolver.DispatchRefreshCalls(dispatcher, response.RefreshCalls);
                    success = true;
                }
                else
                    errorMessage = (response.Message ?? "No line added.");
            }
            else
                errorMessage = (response?.Message ?? "Failed updating field.")
                        + "\n"
                        + (response?.ErrorCause ?? "Unknown error.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error committing new delivery account data");
        }
        finally
        {
            if (!success)
                dispatcher.Dispatch(new FetchNewDeliveryAccountFailureAction(errorMessage));
        }
    }

    [EffectMethod]
    public async Task HandleResetNewDeliveryAccountAction(ResetNewDeliveryAccountAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Resetting new delivery account");
            var response = await _deliveryInfoRepo.ResetNewDeliveryAccountAsync()
                ?? throw new Exception("Error resetting new delivery account");
            _stateResolver.DispatchRefreshCalls(dispatcher, response.RefreshCalls);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error resetting new delivery account data");
        }
    }

    [EffectMethod]
    public async Task HandleFetchDeliveryContactsAction(FetchDeliveryContactsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            _logger.LogInformation("Fetching delivery contacts for {BasketId}", action.BasketId);
            var contactList = await _deliveryInfoRepo.GetDeliverToContactsAsync(action.Filter);
            dispatcher.Dispatch(new FetchDeliveryContactsSuccessAction(contactList, isFiltered));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching delivery contacts data");
            dispatcher.Dispatch(new FetchDeliveryContactsFailureAction(ex.Message));
        }
    }
}