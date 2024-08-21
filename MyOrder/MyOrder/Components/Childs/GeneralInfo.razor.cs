
using MyOrder.Components.Shared;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
{
    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state, string basketId)
    {
        return new FetchGeneralInfoAction(state, basketId);
    }
    protected override void CacheNewFields()
    {
        
    }
}
