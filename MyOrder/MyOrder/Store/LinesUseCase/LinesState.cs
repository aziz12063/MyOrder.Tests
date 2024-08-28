using Fluxor;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase
{
    [FeatureState]
    public class LinesState : StateBase
    {
        public BasketOrderLinesDto? BasketOrderLines {  get; }
        public LinesState() : base(true) { }

        public LinesState(BasketOrderLinesDto? basketOrderLines) : base(false)
        {
            BasketOrderLines = basketOrderLines;
        }
    }
}
