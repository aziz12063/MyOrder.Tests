using Fluxor;
using MudBlazor;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.Base;
using System.Security.Claims;

namespace MyOrder.Store.GeneralInfoUseCase;

[FeatureState]
public class GeneralInfoState : StateBase
{
    public GeneralInfoDto? GeneralInfo { get; }
    public ClaimsPrincipal? User { get; }

    public GeneralInfoState() : base(true) { } 

    public GeneralInfoState(GeneralInfoDto? generalInfo, ClaimsPrincipal? user) : base(false)
    {
        GeneralInfo = generalInfo;
        User = user;
    }
}
