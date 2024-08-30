using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase
{
    public class FetchLinesAction(LinesState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchLinesSuccessAction(BasketOrderLinesDto? basketOrderLinesDto, 
                                         List<BasketValueDto?>? updateReasons,
                                         List<BasketValueDto?>? logisticFlows)
    {
        public BasketOrderLinesDto? BasketOrderLinesDto { get; } = basketOrderLinesDto;
        public List<BasketValueDto?>? UpdateReasons { get; } = updateReasons;
        public List<BasketValueDto?>? LogisticFlows { get; } = logisticFlows;

    }

    public class FetchLinesFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }

}
