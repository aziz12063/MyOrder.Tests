using Fluxor;
using MyOrder.Store.Base;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.LinesUseCase;
using MyOrder.Store.NotificationsUseCase;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Services;

public class StateResolver : IStateResolver
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, Func<IDispatcher, string, StateBase>> _refreshCallActions;

    public StateResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _refreshCallActions = new Dictionary<string, Func<IDispatcher, string, StateBase>>
        {
            { "generalInfo", CreateDispatchAction<GeneralInfoState, FetchGeneralInfoAction> },
            { "orderInfo", CreateDispatchAction<OrderInfoState, FetchOrderInfoAction> },
            { "deliveryInfo", CreateDispatchAction<DeliveryInfoState, FetchDeliveryInfoAction> },
            { "invoiceInfo", CreateDispatchAction<InvoiceInfoState, FetchInvoiceInfoAction> },
            { "tradeInfo", CreateDispatchAction<TradeInfoState, FetchTradeInfoAction> },
            { "pricesInfo", CreateDispatchAction<PricesInfoState, FetchPricesInfoAction> },
            { "notifications", CreateDispatchAction<NotificationsState, FetchNotificationsAction> },
            { "orderLines", CreateDispatchAction<LinesState, FetchLinesAction> }
        // Add other mappings here as needed : Coupons, Warranty, etc.
        };
    }

    private StateBase ResolveState<TState>() where TState : StateBase
    {
        return _serviceProvider.GetRequiredService<IState<TState>>().Value;
    }

    private StateBase CreateDispatchAction<TState, TAction>(IDispatcher dispatcher, string basketId)
        where TState : StateBase
        where TAction : FetchDataActionBase
    {
        var state = ResolveState<TState>();
        if (state == null)
        {
            throw new InvalidOperationException($"Failed to resolve state of type {typeof(TState).Name}");
        }

        var action = Activator.CreateInstance(typeof(TAction), state, basketId)
                     ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TAction).Name}.");

        dispatcher.Dispatch(action);
        return state;
    }

    public void DispatchRefreshAction(string key, IDispatcher dispatcher, string basketId)
    {
        if (_refreshCallActions.TryGetValue(key, out var createAction))
        {
            createAction(dispatcher, basketId);
        }
        else
        {
            throw new KeyNotFoundException($"No refresh action found for key: {key}");
        }
    }
}

//public class StateResolver : IStateResolver
//{
//    private readonly IServiceProvider _serviceProvider;
//    private readonly Dictionary<string, Action<IDispatcher, string>> _refreshCallActions;

//    public StateResolver(IServiceProvider serviceProvider)
//    {
//        _serviceProvider = serviceProvider;
//        _refreshCallActions = new Dictionary<string, Action<IDispatcher, string>>()
//        {
//            {
//                "generalInfo",
//                (dispatcher, basketId) =>
//                    dispatcher.Dispatch(new FetchGeneralInfoAction((GeneralInfoState) ResolveState(typeof(GeneralInfoState)), basketId))
//            },
//            {
//                "orderInfo",
//                (dispatcher, basketId) =>
//                    dispatcher.Dispatch(new FetchOrderInfoAction((OrderInfoState) ResolveState(typeof(OrderInfoState)), basketId))
//            },
//            {
//                "deliveryInfo",
//                (dispatcher, basketId) =>
//                    dispatcher.Dispatch(new FetchDeliveryInfoAction((DeliveryInfoState) ResolveState(typeof(DeliveryInfoState)), basketId))
//            },
//            {
//                "invoiceInfo",
//                (dispatcher, basketId) =>
//                    dispatcher.Dispatch(new FetchInvoiceInfoAction((InvoiceInfoState) ResolveState(typeof(InvoiceInfoState)), basketId))
//            },
//            {
//                "tradeInfo",
//                (dispatcher, basketId) =>
//                    dispatcher.Dispatch(new FetchTradeInfoAction((TradeInfoState) ResolveState(typeof(TradeInfoState)), basketId))
//            },
//            {
//                "pricesInfo",
//                (dispatcher, basketId) =>
//                    dispatcher.Dispatch(new FetchPricesInfoAction((PricesInfoState) ResolveState(typeof(PricesInfoState)), basketId))
//            }
        
//    //{ "coupons" , (dispatcher, basketId) => dispatcher.Dispatch(new FetchPricesInfoAction(basketId)) },
//    //{ "warrantyC"
//    //{ "notifications", dispatcher => dispatcher.Dispatch(new FetchNotificationsAction()) },
//};
//    }


//    public StateBase ResolveState(string key)
//    {
//        return key switch
//        {
//            "generalInfo" => _serviceProvider.GetRequiredService<IState<GeneralInfoState>>().Value,
//            "orderInfo" => _serviceProvider.GetRequiredService<IState<OrderInfoState>>().Value,
//            "deliveryInfo" => _serviceProvider.GetRequiredService<IState<DeliveryInfoState>>().Value,
//            "invoiceInfo" => _serviceProvider.GetRequiredService<IState<InvoiceInfoState>>().Value,
//            "tradeInfo" => _serviceProvider.GetRequiredService<IState<TradeInfoState>>().Value,
//            "pricesInfo" => _serviceProvider.GetRequiredService<IState<PricesInfoState>>().Value,
//            _ => throw new KeyNotFoundException($"No state found for key: {key}")
//        };
//    }

//    public void DispatchRefreshAction(string key, IDispatcher dispatcher, string basketId)
//    {
//        if (_refreshCallActions.TryGetValue(key, out var action))
//        {
//            action(dispatcher, basketId);
//        }
//        else
//        {
//            throw new KeyNotFoundException($"No refresh action found for key: {key}");
//        }
//    }
//}