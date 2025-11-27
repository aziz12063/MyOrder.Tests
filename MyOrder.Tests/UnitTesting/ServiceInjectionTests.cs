using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MyOrder.Components.Childs.Lines;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Services;
using MyOrder.Store.LinesUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.MyOrder;

public class ServiceInjectionTests : TestContext
{
    /// <summary>
    /// By Testing DI i should make  services public in the component
    /// </summary>
    [Fact]
    public void Test_ModalService_Injection()
    {
        // Arrange
        var mockedModalService = new Mock<IModalService>();
        var expectedDialogReference = new Mock<IDialogReference>();
        var expectedTabIndex = AddLineDialogTab.AddLine;

        mockedModalService
            .Setup(m => m.OpenAddLineDialogAsync(expectedTabIndex))
            .ReturnsAsync(expectedDialogReference.Object);

        
        Services.AddScoped<IModalService>(provider => mockedModalService.Object);

        Lines lines = new Lines();
        // I make modalservice public in Lines component to be able to inject it in tests
        lines.ModalService = mockedModalService.Object;

        // Act
        var result = lines.OpenAddLineDialogAsync(expectedTabIndex).Result;

        // Assert
        Assert.Equal(expectedDialogReference.Object, result);

        mockedModalService.Verify(x => x.OpenAddLineDialogAsync(expectedTabIndex), Times.Once);

    }


    /// <summary>
    /// This keep Items private in the component
    /// but here i need to inject all services, not just the service needed for the test.
    /// </summary>
    [Fact]
    public void Test_ModalService_Injection_Inject_All_Service()
    {
        // Arrange
        var mockedToastService = new Mock<IToastService>();
        var mockedClipboardService = new Mock<IClipboardService>();
        var mockedEventAggregator = new Mock<IEventAggregator>();
        var mockedModalService = new Mock<IModalService>();

        var expectedDialogReference = new Mock<IDialogReference>();
        var expectedTabIndex = AddLineDialogTab.AddLine;

        mockedModalService
            .Setup(m => m.OpenAddLineDialogAsync(expectedTabIndex))
            .ReturnsAsync(expectedDialogReference.Object);


        Services.AddScoped<IModalService>(provider => mockedModalService.Object);
        Services.AddScoped<IToastService>(provider => mockedToastService.Object);
        Services.AddScoped<IClipboardService>(provider => mockedClipboardService.Object);
        Services.AddScoped<IEventAggregator>(provider => mockedEventAggregator.Object);
        Services.AddFluxor(options =>
           options.ScanAssemblies(typeof(LinesState).Assembly)
       );
        Services.AddScoped<IBasketService, BasketService>();

        // Render the component DI will inject all services automatically
        var lines = RenderComponent<Lines>();
       

        // Act
        var result = lines.Instance.OpenAddLineDialogAsync(expectedTabIndex).Result;


        // Assert
        Assert.Equal(expectedDialogReference.Object, result);

        mockedModalService.Verify(x => x.OpenAddLineDialogAsync(expectedTabIndex), Times.Once);

    }



}
