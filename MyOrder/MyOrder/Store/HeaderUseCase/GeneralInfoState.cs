using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.HeaderUseCase
{
    [FeatureState]
    public class GeneralInfoState
    {
        public bool isLoading { get; set; } = true;
        public BasketGeneralInfoDto BasketGeneralInfoDto { get; } = new();

        public GeneralInfoState() { }

        public GeneralInfoState(BasketGeneralInfoDto basketGeneralInfoDto, bool isLoading)
        {
            BasketGeneralInfoDto = basketGeneralInfoDto;
            this.isLoading = isLoading;
        }

    }
}
