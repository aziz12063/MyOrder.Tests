using Microsoft.Extensions.Logging;
using Moq;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Infrastructure.Repositories.Implementations;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.Infrastructure.Repositories;

public class DeliveryInfoRepoTests
{



    [Fact]
    public void GetBasketDeliveryInfoAsync_Test()
    {
        // Arrange
        var basketDeliveryInfoDto = TestDataLoader.LoadJsonFromFile<BasketDeliveryInfoDto>("deliveryInfo.json");
        var mockApiClient = new Mock<IDeliveryInfoApiClient>();

        mockApiClient
            .Setup(client => client.GetBasketDeliveryInfoAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(basketDeliveryInfoDto);

        var mockLogger = new Mock<ILogger<DeliveryInfoRepository>>();
        var mockEventAggregator = new Mock<IEventAggregator>();
        var mockBasketService = new Mock<IBasketService>();
        mockBasketService.Setup(service => service.BasketId).Returns("test-basket-id");
        mockBasketService.Setup(service => service.CompanyId).Returns("test-company-id");

        var DeliveryInfoRepository = new DeliveryInfoRepository(
            mockApiClient.Object,
            mockEventAggregator.Object,
            mockBasketService.Object,
            mockLogger.Object
        );

        // Act
        var result = DeliveryInfoRepository.GetBasketDeliveryInfoAsync(CancellationToken.None).Result;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(basketDeliveryInfoDto, result);

    }



}
