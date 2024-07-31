using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.GeneralInfoUseCase;


namespace MyOrder.Components.Childs
{
    public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
    {
        protected override FetchGeneralInfoAction CreateFetchAction(string basketId)
        {
            return new FetchGeneralInfoAction(basketId);
        }
    }
}
