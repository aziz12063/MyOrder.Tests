using MyOrder.Components.Common;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
{
    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state, string basketId)
    {
        if(basketId == null)
        {
            Logger.LogWarning("Trying to fetch general info with null basketId at {StackTrace}", LogUtility.GetStackTrace());
            return new FetchGeneralInfoAction(state, string.Empty);
        }
        return new FetchGeneralInfoAction(state, basketId);
    }


#warning TODO: Should be implemented
    protected override void CacheNewFields()
    {
         //cache properties in here (state and stufF...)   
    }
}
