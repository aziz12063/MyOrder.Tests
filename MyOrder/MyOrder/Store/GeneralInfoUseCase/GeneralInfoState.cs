using Fluxor;
using MudBlazor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.GeneralInfoUseCase;

[FeatureState]
public class GeneralInfoState 
{
    public BasketGeneralInfoDto? GeneralInfo { get; }
    public bool IsLoading { get; } = true;

    public GeneralInfoState() { }

    public GeneralInfoState(BasketGeneralInfoDto? generalInfo)
    {
        GeneralInfo = generalInfo;
        IsLoading = false;
    }
}
