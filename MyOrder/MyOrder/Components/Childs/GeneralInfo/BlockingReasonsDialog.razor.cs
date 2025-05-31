using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.GeneralInfoUseCase;

namespace MyOrder.Components.Childs.GeneralInfo;

public partial class BlockingReasonsDialog : FluxorComponentBase<BlockingReasonsState, FetchBlockingReasonsAction> 
{
    private List<BasketBlockingReasonDto?>? blockingReasons;
       
    protected override FetchBlockingReasonsAction CreateFetchAction(BlockingReasonsState state) => new(state);

    protected override void CacheNewFields()
    {
        blockingReasons = State.Value.BlockingReasons?.BlockingReasons
            ?? throw new ArgumentNullException(nameof(State.Value.BlockingReasons.BlockingReasons));
    }
}
