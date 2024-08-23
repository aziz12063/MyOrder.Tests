using MyOrder.Components.Common;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
{
    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state, string basketId) => new (state, basketId);


#warning TODO: Should be implemented
    protected override void CacheNewFields()
    {
         //cache properties in here (state and stufF...)   
    }
}
