using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class FetchNewDeliveryContactAction(NewDeliveryContactState state, string? contactId = null) : FetchDataActionBase(state)
{
    public string? ContactId { get; } = contactId;
}

public class FetchNewDeliveryContactSuccessAction(DeliveryContactDraft? deliveryContactDraft)
{
    public DeliveryContactDraft? DeliveryContactDraft { get; } = deliveryContactDraft;
}

public class FetchNewDeliveryContactFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class ResetNewDeliveryContactAction()
{ }

public class CommitNewDeliveryContactAction()
{ }