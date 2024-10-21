using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase;

public class FetchLinesAction(LinesState state, string basketId) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
}

public class FetchLinesSuccessAction(BasketOrderLinesDto? basketOrderLinesDto)
{
    public BasketOrderLinesDto? BasketOrderLinesDto { get; } = basketOrderLinesDto;
}

public class FetchLinesFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class DuplicateLinesAction(string basketId, List<int> linesIds)
{
    public string BasketId { get; } = basketId;
    public List<int> LinesIds { get; } = linesIds;
}

public class DeleteLinesAction(string basketId, List<int> linesIds)
{
    public string BasketId { get; } = basketId;
    public List<int> LinesIds { get; } = linesIds;
}

public class EffectOnLinesSuccessAction(string basketId, ProcedureCallResponseDto? procedureCallResponse)
{
    public string BasketId { get; } = basketId;
    public ProcedureCallResponseDto? ProcedureCallResponseDto { get; } = procedureCallResponse;
}

public class EffectOnLinesFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}