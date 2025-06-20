using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public record FetchNewDeliveryAccountAction(string? AccountId = null) : FetchDataActionBase;

public record FetchNewDeliveryAccountSuccessAction(DeliveryAccountDraft DeliveryAccountDraft);

public record FetchNewDeliveryAccountFailureAction(string ErrorMessage);

public record ResetNewDeliveryAccountAction();

public record CommitNewDeliveryAccountAction();