using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;


namespace MyOrder.Components.Childs
{
    public partial class GeneralInfo : LoadableComponent
    {
        private BasketGeneralInfoDto BsktInfo { get; set; } = new ();

        protected override async Task LoadDataAsync()
        {
            BsktInfo = await BasketRepository.GetBasketGeneralInfoAsync(BasketId);
        }
    }
}
