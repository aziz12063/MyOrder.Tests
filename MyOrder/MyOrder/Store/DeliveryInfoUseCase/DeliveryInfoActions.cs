using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class FetchDeliveryInfoAction(DeliveryInfoState state) : FetchDataActionBase(state)
{ }
public class FetchDeliveryInfoSuccessAction(BasketDeliveryInfoDto? basketDeliveryInfo, List<BasketValueDto?>? deliveryModes)
{
    public BasketDeliveryInfoDto? BasketDeliveryInfo { get; } = basketDeliveryInfo;
    public List<BasketValueDto?>? DeliveryModes { get; } = deliveryModes;
}
public class FetchDeliveryInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchDeliveryAccountsAction(DeliveryAccountsState state, string? filter = null, bool? isSearch = null)
    : FetchDataActionBase(state), IFetchAccountsAction
{
    public string? Filter { get; } = filter;
    public bool? IsSearch { get; } = isSearch;
}
public class FetchDeliveryAccountsSuccessAction(List<AccountDto?>? accounts, bool isSearch)
{
    public List<AccountDto?>? DeliveryAccounts { get; } = accounts;
    public bool IsSearch { get; } = isSearch;
}
public class FetchDeliveryAccountsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchDeliveryContactsAction(DeliveryContactsState state, string? filter = null)
    : FetchDataActionBase(state), IFetchContactsAction
{
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

//public record FetchDeliveryModesSuccessAction(List<BasketValueDto?>? deliveryModes)
//{
//    public List<BasketValueDto?>? DeliveryModes { get; } = deliveryModes;
//}

//public record FetchDeliveryModesFailureAction(string errorMessage)
//{
//    public string ErrorMessage { get; } = errorMessage;
//}