using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public record FetchDeliveryInfoAction() : FetchDataActionBase;

public record FetchDeliveryInfoSuccessAction(BasketDeliveryInfoDto BasketDeliveryInfo, List<BasketValueDto?> DeliveryModes);

public record FetchDeliveryInfoFailureAction(string ErrorMessage);

public record FetchDeliveryAccountsAction(string? Filter = null, bool? IsSearch = null)
    : FetchDataActionBase, IFetchAccountsAction;

public record FetchDeliveryAccountsSuccessAction(List<AccountDto?> DeliveryAccounts, bool IsSearch);

public record FetchDeliveryAccountsFailureAction(string ErrorMessage);

public record FetchDeliveryContactsAction(string? Filter = null, bool? Search = null) : FetchDataActionBase, IFetchContactsAction;

public record FetchDeliveryContactsSuccessAction(List<ContactDto?> DeliveryContacts, bool IsFiltered);

public record FetchDeliveryContactsFailureAction(string ErrorMessage);

//public record FetchDeliveryModesSuccessAction(List<BasketValueDto?>? deliveryModes)
//{
//    public List<BasketValueDto?>? DeliveryModes { get; } = deliveryModes;
//}

//public record FetchDeliveryModesFailureAction(string errorMessage)
//{
//    public string ErrorMessage { get; } = errorMessage;
//}