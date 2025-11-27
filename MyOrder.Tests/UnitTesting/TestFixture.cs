using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using MudBlazor;
using MudBlazor.Services;
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

[CollectionDefinition("SharedTestContext")]
public class SharedTestContextCollection : ICollectionFixture<Context_TestFixture> { }

public class Context_TestFixture : TestContext, IDisposable
{
    public Mock<IModalService> MockedModalService { get; private set; }
    public Mock<IToastService> MockedToastService { get; private set; }
    public Mock<IClipboardService> MockedClipboardService { get; private set; }
    public Mock<IEventAggregator> MockedEventAggregator { get; private set; }
    public Mock<IState<SuppliersState>> MockedSuppliersState { get; private set; }
    //public Mock<IState<LinesState>> MockedLinesState { get; private set; }
    public Mock<IBasketService> MockedBasketService { get; private set; }

    public Mock<IDialogService> MockedDialogService { get; private set; }
    public Mock<IDialogReference> MockedDialogReference { get; private set; }


    public Context_TestFixture()
    {
        MockedModalService = new Mock<IModalService>();
        MockedToastService = new Mock<IToastService>();
        MockedClipboardService = new Mock<IClipboardService>();
        MockedEventAggregator = new Mock<IEventAggregator>();
        MockedSuppliersState = new Mock<IState<SuppliersState>>();
        //MockedLinesState = new Mock<IState<LinesState>>();
        MockedBasketService = new Mock<IBasketService>();        
        MockedDialogService = new Mock<IDialogService>();
        MockedDialogReference = new Mock<IDialogReference>();

        Services.AddScoped<IModalService>(provider => MockedModalService.Object);
        Services.AddScoped<IToastService>(provider => MockedToastService.Object);
        Services.AddScoped<IClipboardService>(provider => MockedClipboardService.Object);
        Services.AddScoped<IEventAggregator>(provider => MockedEventAggregator.Object);
        Services.AddScoped<IState<SuppliersState>>(provider => MockedSuppliersState.Object);

      
        Services.AddFluxor(options =>
        {
            options.ScanAssemblies(typeof(SuppliersState).Assembly);
        });


        Services.AddScoped<IBasketService, BasketService>();
        Services.AddMudServices();

        

    }

    public void Dispose()
    {
        base.Dispose();
    }
}


