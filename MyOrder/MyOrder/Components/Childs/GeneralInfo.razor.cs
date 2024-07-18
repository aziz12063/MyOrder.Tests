using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos;


namespace MyOrder.Components.Childs
{
    public partial class GeneralInfo
    {

        private BasketGeneralInfoDto BstInfo { get; set; } = new BasketGeneralInfoDto();

        override protected void OnInitialized()
        {
            base.OnInitialized();
        }


    }
}
