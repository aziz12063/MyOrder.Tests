using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Header
{
    public partial class DeliveryDetails
    {
        public BasketDeliveryInfoDto DeliveryInfo { get; set; } = new();

        private string SelectedAccount
        {
            get => DeliveryInfo.Account?.Value?.AccountId + " - " + DeliveryInfo.Account?.Value?.Name + " - " +
                   DeliveryInfo.Account?.Value?.ZipCode;
            set => throw new NotImplementedException();
        }

        private string SelectedContact
        {
            get => DeliveryInfo.Contact?.Value?.FirstName + " - " + DeliveryInfo.Contact?.Value?.LastName;
            set => throw new NotImplementedException();
        }

        //protected override async Task LoadDataAsync()
        //{
        //    DeliveryInfo = await BasketRepository.GetBasketDeliveryInfoAsync(BasketId);
        //}
    }
}
