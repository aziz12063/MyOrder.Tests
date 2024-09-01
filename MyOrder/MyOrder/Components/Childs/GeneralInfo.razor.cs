using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MyOrder.Components.Common;
using MyOrder.Store.GeneralInfoUseCase;
using System.Security.Claims;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
{
    private ClaimsPrincipal? User { get; set; }

    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state, string basketId) => new (state, basketId);


#warning TODO: Should be implemented
    protected override void CacheNewFields()
    {
        //User = State.Value.User;
         //cache properties in here (state and stufF...)   
    }
}
