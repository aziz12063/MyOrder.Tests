using MyOrder.Store.Base;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Store.NewLineUseCase;

public class FetchNewLineAction(NewLineState state, string basketId) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
}

public class FetchNewLineSuccessAction(BasketLineDto? basketLine)
{
    public BasketLineDto? NewLine { get; } = basketLine;
}

public class FetchNewLineFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class ResetNewLineAction(string basketId)
{
    public string BasketId { get; } = basketId;
}

public class CommitNewLineAction(string basketId)
{
    public string BasketId { get; } = basketId;
}
