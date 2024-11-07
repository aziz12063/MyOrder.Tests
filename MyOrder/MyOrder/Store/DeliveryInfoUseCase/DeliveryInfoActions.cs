using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class FetchDeliveryInfoAction(DeliveryInfoState state, string basketId) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
}
public class FetchDeliveryInfoSuccessAction(BasketDeliveryInfoDto? basketDeliveryInfo)
{
    public BasketDeliveryInfoDto? BasketDeliveryInfo { get; } = basketDeliveryInfo;
}
public class FetchDeliveryInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchDeliveryAccountsAction(DeliveryAccountsState state,
    string basketId, string? filter = null)
    : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
    public string? Filter { get; } = filter;
}
public class FetchDeliveryAccountsSuccessAction(List<AccountDto?>? accounts, bool isFiltered)
{
    public List<AccountDto?>? DeliveryAccounts { get; } = accounts;
    public bool IsFiltered { get; } = isFiltered;
}
public class FetchDeliveryAccountsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchDeliveryContactsAction(DeliveryContactsState state,
    string basketId, string? filter = null)
    : FetchDataActionBase(state), IFetchContactsAction
{
    public string BasketId { get; } = basketId;
    public string? Filter { get; } = filter;
}
public class FetchDeliveryContactsSuccessAction(List<ContactDto?>? contacts, bool isFiltered)
{
    public List<ContactDto?>? DeliveryContacts { get; } = contacts;
    public bool IsFiltered { get; } = isFiltered;
}
public class FetchDeliveryContactsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}