using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

public class FetchInvoiceInfoAction(InvoiceInfoState state, string basketId) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
}

public class FetchInvoiceInfoSuccessAction(BasketInvoiceInfoDto? basketInvoiceInfo)
{
    public BasketInvoiceInfoDto? InvoiceInfo { get; } = basketInvoiceInfo;
}

public class FetchInvoiceInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchInvoiceAccountsAction(InvoiceAccountsState state,
    string basketId, string? filter = null)
    : FetchDataActionBase(state), IFetchAccountsAction
{
    public string BasketId { get; } = basketId;
    public string? Filter { get; } = filter;
}

public class FetchInvoiceAccountsSuccessAction(List<AccountDto?>? accounts, bool isFiltered)
{
    public List<AccountDto?>? Accounts { get; } = accounts;
    public bool IsFiltered { get; } = isFiltered;
}

public class FetchInvoiceAccountsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}