using Fluxor;
using MyOrder.Store.Base;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.LinesUseCase;
using MyOrder.Store.NewLineUseCase;
using MyOrder.Store.NotificationsUseCase;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Services;

public class StateResolver : IStateResolver
{
    private const string GeneralInfo = "generalInfo";
    private const string OrderInfo = "orderInfo";
    private const string DeliveryInfo = "deliveryInfo";
    private const string InvoiceInfo = "invoiceInfo";
    private const string TradeInfo = "tradeInfo";
    private const string PricesInfo = "pricesInfo";
    private const string Notifications = "notifications";
    private const string OrderLines = "orderLines";
    private const string NewLine = "newLine";

    public static readonly Dictionary<Type, string> EndpointFetchActionMap = new()
    {
        { typeof(FetchGeneralInfoAction), GeneralInfo },
        { typeof(FetchOrderInfoAction), OrderInfo },
        { typeof(FetchDeliveryInfoAction), DeliveryInfo },
        { typeof(FetchInvoiceInfoAction), InvoiceInfo },
        { typeof(FetchTradeInfoAction), TradeInfo },
        { typeof(FetchPricesInfoAction), PricesInfo },
        { typeof(FetchNotificationsAction), Notifications },
        { typeof(FetchLinesAction), OrderLines },
        { typeof(FetchNewLineAction), NewLine }
    };

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StateResolver> _logger;
    private readonly Dictionary<string, Func<IDispatcher, string, StateBase>> _refreshCallActions;

    public StateResolver(IServiceProvider serviceProvider, ILogger<StateResolver> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _refreshCallActions = new Dictionary<string, Func<IDispatcher, string, StateBase>>
        {
            { GeneralInfo, CreateDispatchAction<GeneralInfoState, FetchGeneralInfoAction> },
            { OrderInfo, CreateDispatchAction<OrderInfoState, FetchOrderInfoAction> },
            { DeliveryInfo, CreateDispatchAction<DeliveryInfoState, FetchDeliveryInfoAction> },
            { InvoiceInfo, CreateDispatchAction<InvoiceInfoState, FetchInvoiceInfoAction> },
            { TradeInfo, CreateDispatchAction<TradeInfoState, FetchTradeInfoAction> },
            { PricesInfo, CreateDispatchAction<PricesInfoState, FetchPricesInfoAction> },
            { Notifications, CreateDispatchAction<NotificationsState, FetchNotificationsAction> },
            { OrderLines, CreateDispatchAction<LinesState, FetchLinesAction> },
            { NewLine, CreateDispatchAction<NewLineState, FetchNewLineAction> }
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

    public void DispatchRefreshCalls(IDispatcher dispatcher, List<string?>? refreshCalls, string? basketId)
    {
        if (refreshCalls is null
                    || refreshCalls.Count < 1)
        {
            _logger.LogInformation("RefreshCall property is empty. No refresh calls to make.");
            return;
        }

        foreach (var call in refreshCalls)
        {
            if (string.IsNullOrWhiteSpace(call))
            {
                _logger.LogError("Refresh call is null");
                continue;
            }
            _logger.LogInformation("Dispatching refresh action for {Call}", call);
            DispatchRefreshAction(call, dispatcher, basketId!);
        }
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