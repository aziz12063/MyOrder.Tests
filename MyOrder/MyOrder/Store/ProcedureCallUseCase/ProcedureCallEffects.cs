using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Store.ProcedureCallUseCase;

public class ProcedureCallEffects(IBasketRepository basketRepository, ILogger<OrderInfoEffects> logger)
{
    private readonly Dictionary<string, Action<IDispatcher, string>> _refreshCallActions = new()
        {
            { "generalInfo", (dispatcher, basketId) => dispatcher.Dispatch(new FetchGeneralInfoAction(basketId)) },
            { "orderInfo", (dispatcher, basketId) => dispatcher.Dispatch(new FetchOrderInfoAction(basketId)) },
            { "deliveryInfo", (dispatcher, basketId) => dispatcher.Dispatch(new FetchDeliveryInfoAction(basketId)) },
            { "invoiceInfo", (dispatcher, basketId) => dispatcher.Dispatch(new FetchInvoiceInfoAction(basketId)) },
            { "tradeInfo", (dispatcher, basketId) => dispatcher.Dispatch(new FetchTradeInfoAction(basketId)) },
            { "pricesInfo", (dispatcher, basketId) => dispatcher.Dispatch(new FetchPricesInfoAction(basketId)) },
            //{ "coupons" , (dispatcher, basketId) => dispatcher.Dispatch(new FetchPricesInfoAction(basketId)) },
            //{ "warrantyC"
            //{ "notifications", dispatcher => dispatcher.Dispatch(new FetchNotificationsAction()) },
        };

    [EffectMethod]
    public async Task HandlePostProcedureCallAction(PostProcedureCallAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await basketRepository.PostProcedureCallAsync(action.BasketId, action.ProcedureCall);
            dispatcher.Dispatch(new PostProcedureCallSuccessAction(action.BasketId, response));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while posting procedure call");
            dispatcher.Dispatch(new PostProcedureCallFailureAction(e.Message));
        }
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallSuccessAction receivedAction,
        IDispatcher dispatcher)
    {
        if (receivedAction.ProcedureCallResponse.RefreshCalls is null || receivedAction.ProcedureCallResponse.RefreshCalls.Count < 1)
        {
            logger.LogInformation("RefreshCall property is empty. No refresh calls to make.");
            return;
        }

        foreach (var call in receivedAction.ProcedureCallResponse.RefreshCalls)
        {
            if (string.IsNullOrWhiteSpace(call))
            {
                logger.LogError("Refresh call is null");
                continue;
            }

            if (_refreshCallActions.TryGetValue(call, out var refreshAction))
            {
                refreshAction(dispatcher, receivedAction.BasketId);
            }
            else
            {
                logger.LogError("No action mapped for refresh call: {call}", call);
            }
        }
    }
}
