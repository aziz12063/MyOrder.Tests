using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public record FetchNewDeliveryContactAction(string? ContactId = null) : FetchDataActionBase;

public record FetchNewDeliveryContactSuccessAction(DeliveryContactDraft DeliveryContactDraft);

public record FetchNewDeliveryContactFailureAction(string ErrorMessage);

public record ResetNewDeliveryContactAction();