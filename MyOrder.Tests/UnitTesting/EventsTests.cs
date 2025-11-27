using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using MudBlazor;
using MyOrder.Components.Childs.Lines;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Services;
using MyOrder.Store.LinesUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.MyOrder;

[Collection("SharedTestContext")]
public class EventsTests : TestContext
{
    private readonly Context_TestFixture _fixture;
    public EventsTests(Context_TestFixture fixture)
    {
        _fixture = fixture;
    }

    

    [Fact]
    public void OpenSearchSupplierDialog_ModalService_Test()
    {
        // Arrange
        var mockDialogService = _fixture.MockedDialogService;
        var mockDialogReference = _fixture.MockedDialogReference;

        // Simulate dialog result completion
        var tcs = new TaskCompletionSource<DialogResult>();
        tcs.SetResult(DialogResult.Ok(true));
        mockDialogReference.SetupGet(x => x.Result).Returns(tcs.Task);

        // Setup ShowAsync to return mock dialog
        mockDialogService
            .Setup(d => d.ShowAsync<SearchSupplierDialog>(
                "SearchSupplierDialog",
                It.IsAny<DialogOptions>()))
            .ReturnsAsync(mockDialogReference.Object);

        var modalService = new ModalService(mockDialogService.Object);

        // Act
        var dialogRef =  modalService.OpenSearchSupplierDialog();

        // Assert
        Assert.NotNull(dialogRef);
        mockDialogService.Verify(d => d.ShowAsync<SearchSupplierDialog>(
            "SearchSupplierDialog",
            It.Is<DialogOptions>(opts =>
                opts.CloseOnEscapeKey == true &&
                opts.FullWidth == true &&
                opts.MaxWidth == MaxWidth.Medium &&
                opts.CloseButton == true
            )), Times.Once);
    }


    [Fact]
    public void OnSearchSupplierButtonClicked_LineStockQuantities_Test()
    {
       
        // Arrange
        var mockDialogService = new Mock<IDialogService>();
        var mockDialogReference = new Mock<IDialogReference>();

        var mockedState = new Mock<IState<SuppliersState>>();
        var mockedModalService = new Mock<IModalService>();
        var mockedDispatcher = new Mock<IDispatcher>();


        Services.AddScoped<IModalService>(provider => mockedModalService.Object);
        Services.AddScoped<IState<SuppliersState>>(provider => mockedState.Object);
        Services.AddScoped<IDialogService>(provider => mockDialogService.Object);
        Services.AddScoped<IDialogReference>(provider => mockDialogReference.Object);
        Services.AddScoped<IDispatcher>(provider => mockedDispatcher.Object);

        // Simulate dialog result completion
        var tcs = new TaskCompletionSource<DialogResult>();
        tcs.SetResult(DialogResult.Ok(true));

        mockDialogReference.SetupGet(x => x.Result).Returns(tcs.Task);

        mockedModalService.Setup(d => d.OpenSearchSupplierDialog())
                          .ReturnsAsync(mockDialogReference.Object);

        mockedState.SetupGet(s => s.Value).Returns(new SuppliersState
        (
            new List<Supplier?>
            {
                new Supplier("1","Supplier 1", null, null, null, null, null, null, null, null, null, null, null,true ),
            }
        ));

        // Act
        
        var renderedComponent = RenderComponent<LineStockQuantities>(parameters => parameters
            .Add(p => p.BasketLine, new BasketLineDto())
            .Add(p => p.LogisticFlows, new List<BasketValueDto?>())
            //.Add(p => p.SuppliersState, mockedState.Object)

        );
        var OnSearchSupplierButton = renderedComponent.FindAll("button")
                                                      .FirstOrDefault(b => b.InnerHtml.Contains("search", StringComparison.OrdinalIgnoreCase));
        OnSearchSupplierButton.Click();

        // Assert
        Assert.NotNull(OnSearchSupplierButton);
        mockedModalService.Verify(x => x.OpenSearchSupplierDialog(), Times.Once);

    }

    //[Fact]
    //public void TestEventAggregator()
    //{
    //    // Arrange
    //    var eventAggregator = new EventAggregator();
    //    var eventHandler = new Mock<IEventHandler<MyEvent>>();
    //    eventAggregator.Subscribe(eventHandler.Object);
    //    // Act
    //    var myEvent = new MyEvent { Message = "Hello, World!" };
    //    eventAggregator.Publish(myEvent);
    //    // Assert
    //    eventHandler.Verify(h => h.Handle(myEvent), Times.Once);
    //}


}
