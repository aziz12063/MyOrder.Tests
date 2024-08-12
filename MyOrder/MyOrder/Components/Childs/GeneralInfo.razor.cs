using MyOrder.Components.Childs.Shared;
using MyOrder.Store.GeneralInfoUseCase;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
{
    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state, string basketId)
    {
        return new FetchGeneralInfoAction(state, basketId);
    }
}
