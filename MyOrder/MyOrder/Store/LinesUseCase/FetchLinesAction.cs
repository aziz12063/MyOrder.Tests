using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase
{
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

}
