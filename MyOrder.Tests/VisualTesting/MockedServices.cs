using Fluxor;
using Moq;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.OrderInfoUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.VisualTesting
{
    internal class MockedServices
    {
        private readonly Mock<IModalService> mockedModalService = new Mock<IModalService>();
        private readonly Mock<IBasketService> mockedBasketService = new Mock<IBasketService>();
        private readonly Mock<ITradeInfoRepository> mockedTradInfo = new Mock<ITradeInfoRepository>();
        private readonly Mock<IBasketResourcesRepository> mockedBasketResourcesRepository = new Mock<IBasketResourcesRepository>();
        private readonly Mock<IBasketActionsRepository> mockedBasketActionsRepository = new Mock<IBasketActionsRepository>();
        private readonly Mock<IStateResolver> mockedStateResolver = new Mock<IStateResolver>();
        private readonly Mock<IToastService> mockedToastService = new Mock<IToastService>();
        private readonly Mock<IPricesInfoRepository> mockedIPricesInfoRepository = new Mock<IPricesInfoRepository>();
        private readonly Mock<IOrderInfoRepository> mockedIOrderInfoRepository = new Mock<IOrderInfoRepository>();
        private readonly Mock<IGeneralInfoRepository> mockedIGeneralInfoRepository = new Mock<IGeneralInfoRepository>();

        private readonly Mock<INewOrderLineRepository> mockedINewOrderLineRepository = new Mock<INewOrderLineRepository>();
        private readonly Mock<IOrderLinesRepository> mockedIOrderLinesRepository = new Mock<IOrderLinesRepository>();
        private readonly Mock<IInvoiceInfoRepository> mockedIInvoiceInfoRepository = new Mock<IInvoiceInfoRepository>();
        private readonly Mock<IDeliveryInfoRepository> mockedIDeliveryInfoRepository = new Mock<IDeliveryInfoRepository>();
        private readonly Mock<IUrlService> mockedIUrlService = new Mock<IUrlService>();
        private readonly Mock<IBasketItemsRepository> mockedIBasketItemsRepository = new Mock<IBasketItemsRepository>();

        private readonly Mock<IState<OrderInfoState>> mockedOrderInfoState = new Mock<IState<OrderInfoState>>();
        private readonly Mock<IDispatcher> mockedDispatcher = new Mock<IDispatcher>();

        public MockedServices()
        {
            mockedOrderInfoState.SetupGet(x => x.Value).Returns(new OrderInfoState());
        }
    }
}
