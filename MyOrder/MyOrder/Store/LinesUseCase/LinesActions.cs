using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase;

public class FetchLinesAction(LinesState state) : FetchDataActionBase(state)
{ }

public class FetchLinesSuccessAction(BasketOrderLinesDto? basketOrderLinesDto)
{
    public BasketOrderLinesDto? BasketOrderLinesDto { get; } = basketOrderLinesDto;
}

public class FetchLinesFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class DuplicateLinesAction(List<int> linesIds)
{
    public List<int> LinesIds { get; } = linesIds;
}

public class DeleteLinesAction(List<int> linesIds)
{
    public List<int> LinesIds { get; } = linesIds;
}

public class EffectOnLinesSuccessAction(ProcedureCallResponseDto? procedureCallResponse)
{
    public ProcedureCallResponseDto? ProcedureCallResponseDto { get; } = procedureCallResponse;
}

public class EffectOnLinesFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public record FetchSuppliersAction(
    SuppliersState State,
    bool Search,
    string? Filter = null);

public record FetchSuppliersSuccessAction(List<Supplier?>? Suppliers);

public record FetchSuppliersFailureAction(string ErrorMessage);