using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class FetchNewDeliveryAccountAction(NewDeliveryAccountState state, string? accountId = null) : FetchDataActionBase(state)
{ 
    public string? AccountId { get; } = accountId;
}

public class FetchNewDeliveryAccountSuccessAction(DeliveryAccountDraft? deliveryAccountDraft)
{
    public DeliveryAccountDraft? DeliveryAccountDraft { get; } = deliveryAccountDraft;
}

public class FetchNewDeliveryAccountFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class ResetNewDeliveryAccountAction()
{ }

public class CommitNewDeliveryAccountAction()
{ }