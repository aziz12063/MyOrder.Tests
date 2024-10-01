using MyOrder.Shared.Dtos;

namespace MyOrder.Store.ReloadUseCase;

public class ReloadAction(string basketId)
{
    public string BasketId { get; } = basketId;
}

public class ReloadSuccessAction(NewOrderContextResponse response)
{
    public NewOrderContextResponse Response { get; } = response;
}

public class ReloadFailureAction(NewOrderContextResponse response)
{
    public NewOrderContextResponse Response { get; } = response;
}
