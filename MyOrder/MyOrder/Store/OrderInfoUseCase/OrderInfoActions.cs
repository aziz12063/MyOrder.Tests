using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

public class FetchOrderInfoAction(OrderInfoState state) : FetchDataActionBase(state)
{}
public class FetchOrderInfoSuccessAction(BasketOrderInfoDto basketOrderInfo, List<BasketValueDto?>? webOrigins)
{
    public BasketOrderInfoDto? BasketOrderInfo { get; } = basketOrderInfo;
    public List<BasketValueDto?>? WebOrigins { get; } = webOrigins;
}
public class FetchOrderInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
public class FetchOrderContactsAction(OrderContactsState state, string? filter = null) 
    : FetchDataActionBase(state), IFetchContactsAction
{
    public string? Filter { get; } = filter;
}
public class FetchOrderContactsSuccessAction(List<ContactDto?>? contacts, bool isFiltered)
{
    public List<ContactDto?>? OrderContacts { get; } = contacts;
    public bool IsFiltered { get; } = isFiltered;
}
public class FetchOrderContactsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}