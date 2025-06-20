using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.GeneralInfoUseCase;

namespace MyOrder.Components.Childs.GeneralInfo;

public partial class BlockingReasonsDialog : FluxorComponentBase<BlockingReasonsState, FetchBlockingReasonsAction> 
{
    private ICollection<BasketBlockingReasonDto?>? BlockingReasons => State.Value.BlockingReasons.BlockingReasons;

    protected override FetchBlockingReasonsAction CreateFetchAction() => new();
}