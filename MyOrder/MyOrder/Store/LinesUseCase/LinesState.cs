using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase
{
    [FeatureState]
    public class LinesState : StateBase
    {
        public BasketOrderLinesDto? BasketOrderLines {  get; }
        public List<BasketValueDto?>? UpdateReasons { get; }
        public List<BasketValueDto?>? LogisticFlows { get; }

        public LinesState() : base(true) { }

        public LinesState(BasketOrderLinesDto? basketOrderLines, 
                          List<BasketValueDto?>? updateReasons,
                          List<BasketValueDto?>? logisticFlows) : base(false)
        {
            BasketOrderLines = basketOrderLines;
            UpdateReasons = updateReasons;
            LogisticFlows = logisticFlows;
        }
    }
}
