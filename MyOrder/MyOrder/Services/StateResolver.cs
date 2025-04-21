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
    private const string DeliveryModes = "deliveryModes";
    private const string DeliveryAccounts = "deliverToAccounts";
    private const string NewDeliveryAccount = "newDeliverToAccount";
    private const string DeliveryContacts = "deliverToContacts";
    private const string InvoiceInfo = "invoiceInfo";
    private const string InvoiceAccounts = "invoiceToAccounts";
    private const string TradeInfo = "tradeInfo";
    private const string PricesInfo = "pricesInfo";
    private const string Notifications = "notifications";
    private const string OrderLines = "orderLines";
    private const string NewLine = "newLine";
    private const string PaymentAuthorization = "paymentAuthorization";

    public static readonly Dictionary<Type, string> EndpointFetchActionMap = new()
    {
        { typeof(FetchGeneralInfoAction), GeneralInfo },
        { typeof(FetchOrderInfoAction), OrderInfo },
        { typeof(FetchDeliveryInfoAction), DeliveryInfo },
        { typeof(FetchNewDeliveryAccountAction), NewDeliveryAccount },
        { typeof(FetchInvoiceInfoAction), InvoiceInfo },
        { typeof(FetchInvoiceAccountsAction), InvoiceAccounts },
        { typeof(FetchTradeInfoAction), TradeInfo },
        { typeof(FetchPricesInfoAction), PricesInfo },
        { typeof(FetchNotificationsAction), Notifications },
        { typeof(FetchLinesAction), OrderLines },
        { typeof(FetchNewLineAction), NewLine },
        { typeof(FetchPaymentAuthorizationAction), PaymentAuthorization }
    };

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StateResolver> _logger;
    private readonly Dictionary<string, List<Func<IDispatcher, StateBase>>> _refreshCallActions;

    public StateResolver(IServiceProvider serviceProvider, ILogger<StateResolver> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _refreshCallActions = new Dictionary<string, List<Func<IDispatcher, StateBase>>>
        {
            { GeneralInfo, new () { CreateDispatchAction<GeneralInfoState, FetchGeneralInfoAction> } },
            { OrderInfo, new ()
                {
                    CreateDispatchAction<OrderInfoState, FetchOrderInfoAction>,
                    CreateDispatchAction<OrderContactsState, FetchOrderContactsAction>
                }
            },
            { DeliveryInfo, new () { CreateDispatchAction<DeliveryInfoState, FetchDeliveryInfoAction> } },
            { DeliveryModes, new () { CreateDispatchAction<DeliveryInfoState, FetchDeliveryInfoAction> } }, // Unecessary. Remove to avoid redundant call
            { DeliveryAccounts, new() { CreateDispatchAction<DeliveryAccountsState, FetchDeliveryAccountsAction> } },
            { NewDeliveryAccount, new () { CreateDispatchAction<NewDeliveryAccountState, FetchNewDeliveryAccountAction> } },
            { DeliveryContacts, new() { CreateDispatchAction<DeliveryContactsState, FetchDeliveryContactsAction> } },
            { InvoiceInfo, new () { CreateDispatchAction<InvoiceInfoState, FetchInvoiceInfoAction> } },
            { InvoiceAccounts, new () { CreateDispatchAction<InvoiceAccountsState, FetchInvoiceAccountsAction> } },
            { TradeInfo, new () { CreateDispatchAction<TradeInfoState, FetchTradeInfoAction> } },
            { PricesInfo, new () { CreateDispatchAction<PricesInfoState, FetchPricesInfoAction> } },
            { Notifications, new () { CreateDispatchAction<NotificationsState, FetchNotificationsAction> } },
            { OrderLines, new () { CreateDispatchAction<LinesState, FetchLinesAction> } },
            { NewLine, new () { CreateDispatchAction<NewLineState, FetchNewLineAction> } },
            { PaymentAuthorization, new () { CreateDispatchAction<PaymentAuthorizationState, FetchPaymentAuthorizationAction> } },
            // Add other mappings here as needed : Coupons, Warranty, etc.
        };
    }

    private StateBase CreateDispatchAction<TState, TAction>(IDispatcher dispatcher)
    where TState : StateBase
    where TAction : FetchDataActionBase
    {
        var state = ResolveState<TState>()
            ?? throw new InvalidOperationException($"Failed to resolve state of type {typeof(TState).Name}");
        try
        {
            var action = Activator.CreateInstance(
                typeof(TAction),
                BindingFlags.CreateInstance |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.OptionalParamBinding,
                null,
                [state],
                null)
                ?? throw new InvalidOperationException($"Failed to create an instance of {typeof(TAction).Name}.");

            dispatcher.Dispatch(action);
            return state;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create an instance of {Action}", typeof(TAction).Name);
            throw;
        }
    }

    private StateBase ResolveState<TState>() where TState : StateBase
    {
        return _serviceProvider.GetRequiredService<IState<TState>>().Value;
    }

    public void DispatchRefreshCalls(IDispatcher dispatcher, List<string?>? refreshCalls)
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
            DispatchRefreshAction(dispatcher, call);
        }
    }

    public void DispatchRefreshAction(IDispatcher dispatcher, string key)
    {
        if (_refreshCallActions.TryGetValue(key, out var createActionList))
        {
            foreach (var createAction in createActionList)
            {
                createAction(dispatcher);
            }
        }
        else
        {
            throw new KeyNotFoundException($"No refresh action found for key: {key}");
        }
    }
}