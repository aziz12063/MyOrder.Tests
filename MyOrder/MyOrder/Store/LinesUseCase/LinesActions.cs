using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase;

public record FetchLinesAction() : FetchDataActionBase;

public record FetchLinesSuccessAction(BasketOrderLinesDto BasketOrderLinesDto);

public record FetchLinesFailureAction(string ErrorMessage);

public record DuplicateLinesAction(List<int> LinesIds);

public record DeleteLinesAction(List<int> LinesIds);

public record EffectOnLinesSuccessAction(ProcedureCallResponseDto ProcedureCallResponse);

public record EffectOnLinesFailureAction(string ErrorMessage);

public record FetchSuppliersAction(
    bool Search,
    string? Filter = null);

public record FetchSuppliersSuccessAction(List<Supplier?> Suppliers);

public record FetchSuppliersFailureAction(string ErrorMessage);