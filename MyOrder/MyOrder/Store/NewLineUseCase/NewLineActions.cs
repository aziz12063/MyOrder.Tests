using MyOrder.Store.Base;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.NewLineUseCase;

public class FetchNewLineAction(NewLineState state) : FetchDataActionBase(state)
{ }

public class FetchNewLineSuccessAction(BasketLineDto? basketLine)
{
    public BasketLineDto? NewLine { get; } = basketLine;
}

public class FetchNewLineFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class ResetNewLineAction()
{ }

public class CommitNewLineAction()
{ }

public class PostFreeTextAction(List<string?> freeTexts)
{
    public List<string?> FreeTexts { get; } = freeTexts;
}

public class PostFreeTextSuccessAction(ProcedureCallResponseDto procedureCallResponse)
{
    public ProcedureCallResponseDto ProcedureCallResponse { get; set; } = procedureCallResponse;
}

public class PostFreeTextFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
