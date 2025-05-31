using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.GeneralInfoUseCase;

[FeatureState]
public class BlockingReasonsState : StateBase
{
    public BasketBlockingReasonsDto? BlockingReasons { get; }

    public BlockingReasonsState() : base(true) { }

    public BlockingReasonsState(BasketBlockingReasonsDto? blockingReasons) : base(false)
    {
        BlockingReasons = blockingReasons;
    }
}
