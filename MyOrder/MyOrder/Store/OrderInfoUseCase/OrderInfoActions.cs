using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

public record FetchOrderInfoAction() : FetchDataActionBase;

public record FetchOrderInfoSuccessAction(BasketOrderInfoDto BasketOrderInfo, List<BasketValueDto?> WebOrigins);

public record FetchOrderInfoFailureAction(string ErrorMessage);

public record FetchOrderContactsAction(string? Filter = null, bool? Search = null) 
    : FetchDataActionBase, IFetchContactsAction;

public record FetchOrderContactsSuccessAction(List<ContactDto?> OrderContacts, bool IsFiltered);

public record FetchOrderContactsFailureAction(string ErrorMessage);