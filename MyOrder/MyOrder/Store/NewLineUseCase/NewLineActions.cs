using MyOrder.Store.Base;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.NewLineUseCase;

public record FetchNewLineAction() : FetchDataActionBase;

public record FetchNewLineSuccessAction(BasketLineDto NewLine);

public record FetchNewLineFailureAction(string ErrorMessage);

public record ResetNewLineAction();

public record CommitNewLineAction();

public record PostFreeTextAction(List<string?> FreeTexts);

public record PostFreeTextSuccessAction(ProcedureCallResponseDto ProcedureCallResponse);

public record PostFreeTextFailureAction(string ErrorMessage);
