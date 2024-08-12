using Fluxor;
using MudBlazor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.GeneralInfoUseCase;

[FeatureState]
public class GeneralInfoState : StateBase
{
    public BasketGeneralInfoDto? GeneralInfo { get; }

    public GeneralInfoState() : base(true) { } 

    public GeneralInfoState(BasketGeneralInfoDto? generalInfo) : base(false)
    {
        GeneralInfo = generalInfo;
    }
}
