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
using System.Reflection;

namespace MyOrder.Services;

public class StateResolver : IStateResolver
{
    private const string GeneralInfo = "generalInfo";
    private const string OrderInfo = "orderInfo";
    private const string DeliveryInfo = "deliveryInfo";
    private const string NewDeliveryAccount = "newDeliverToAccount";
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
        { typeof(FetchNewDeliveryAccountAction), NewDeliveryAccount },
        { typeof(FetchInvoiceInfoAction), InvoiceInfo },
        { typeof(FetchTradeInfoAction), TradeInfo },
        { typeof(FetchPricesInfoAction), PricesInfo },
        { typeof(FetchNotificationsAction), Notifications },
        { typeof(FetchLinesAction), OrderLines },
        { typeof(FetchNewLineAction), NewLine }
    };

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StateResolver> _logger;
    private readonly Dictionary<string, List<Func<IDispatcher, string, StateBase>>> _refreshCallActions;

    public StateResolver(IServiceProvider serviceProvider, ILogger<StateResolver> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _refreshCallActions = new Dictionary<string, List<Func<IDispatcher, string, StateBase>>>
        {
            { GeneralInfo, new () { CreateDispatchAction<GeneralInfoState, FetchGeneralInfoAction> } },
            { OrderInfo, new ()
                {
                    CreateDispatchAction<OrderInfoState, FetchOrderInfoAction>,
                    CreateDispatchAction<OrderContactsState, FetchOrderContactsAction>
                }
            },
            { DeliveryInfo, new ()
                {
                    CreateDispatchAction<DeliveryInfoState, FetchDeliveryInfoAction>,
                    CreateDispatchAction<DeliveryAccountsState, FetchDeliveryAccountsAction>,
                    CreateDispatchAction<DeliveryContactsState, FetchDeliveryContactsAction>
                }
            },
            { NewDeliveryAccount, new () { CreateDispatchAction<NewDeliveryAccountState, FetchNewDeliveryAccountAction> } },
            { InvoiceInfo, new () { CreateDispatchAction<InvoiceInfoState, FetchInvoiceInfoAction> } },
            { TradeInfo, new () { CreateDispatchAction<TradeInfoState, FetchTradeInfoAction> } },
            { PricesInfo, new () { CreateDispatchAction<PricesInfoState, FetchPricesInfoAction> } },
            { Notifications, new () { CreateDispatchAction<NotificationsState, FetchNotificationsAction> } },
            { OrderLines, new () { CreateDispatchAction<LinesState, FetchLinesAction> } },
            { NewLine, new () { CreateDispatchAction<NewLineState, FetchNewLineAction> } }
            // Add other mappings here as needed : Coupons, Warranty, etc.
        };
    }

    private StateBase CreateDispatchAction<TState, TAction>(IDispatcher dispatcher, string basketId)
    where TState : StateBase
    where TAction : FetchDataActionBase
    {
        var state = ResolveState<TState>() ?? throw new InvalidOperationException($"Failed to resolve state of type {typeof(TState).Name}");

        var action = Activator.CreateInstance(
            typeof(TAction),
            BindingFlags.CreateInstance |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.OptionalParamBinding,
            null,
            [state, basketId],
            null)
            ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TAction).Name}.");

        dispatcher.Dispatch(action);
        return state;
    }

    private StateBase ResolveState<TState>() where TState : StateBase
    {
        return _serviceProvider.GetRequiredService<IState<TState>>().Value;
    }
#warning refactor to remove basketId
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
        if (_refreshCallActions.TryGetValue(key, out var createActionList))
        {
            foreach (var createAction in createActionList)
            {
                createAction(dispatcher, basketId);
            }
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