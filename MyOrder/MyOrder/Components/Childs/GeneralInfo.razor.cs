using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;
using MyOrder.Store.HeaderUseCase;
using System;

namespace MyOrder.Components.Childs
{
    public partial class GeneralInfo : IDisposable
    {
        [Inject]
        private IDispatcher Dispatcher { get; set; }

        [Inject]
        private IState<GeneralInfoState> State { get; set; }

        private BasketGeneralInfoDto BstInfo { get; set; } = new BasketGeneralInfoDto();

        override protected void OnInitialized()
        {
            base.OnInitialized();
            State.StateChanged += UpdateGeneralInfo;
            Dispatcher.Dispatch(new FetchGeneralInfoAction(GlobalParms.TEST_BASKET_ID));
        }

        private void UpdateGeneralInfo(object sender, EventArgs e)
        {
            BstInfo = State.Value.BasketGeneralInfoDto;
        }


        public void Dispose()
        {
            State.StateChanged -= UpdateGeneralInfo;
        }

            }
}
