using Bunit;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using MyOrder.Components.Common.Input;
using MyOrder.Services;
using MyOrder.Shared.Dtos.SharedComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.UnitTesting.GenericInput;

public abstract class GenericInputTestBase : TestContext
{
    protected readonly Mock<IDispatcher> DispatcherMock;
    protected readonly Mock<ILogger<GenericInputBase<string>>> LoggerMock;

    protected GenericInputTestBase()
    {
        DispatcherMock = new Mock<IDispatcher>();
        LoggerMock = new Mock<ILogger<GenericInputBase<string>>>();

        Services.AddScoped<IDispatcher>( p =>DispatcherMock.Object);
        Services.AddScoped<ILogger>(p =>LoggerMock.Object);
        Services.AddMudServices();
    }

    protected IRenderedComponent<TComponent> RenderInputComponent<TComponent, TValue>(
        Field<TValue> field,
        bool? readOnly = null,
        bool hideLabel = false,
        MudBlazor.Margin margin = MudBlazor.Margin.Dense,
        Type? fetchActionType = null,
        EventCallback? onValueChange = null,
        List<TValue>? items = null)
        where TComponent : GenericInputBase<TValue>
    {
        var render = RenderComponent<TComponent>(parameters =>
        {
            parameters.Add(p => p.Field, field);
            parameters.Add(p => p.ReadOnly, readOnly);
            parameters.Add(p => p.HideLabel, hideLabel);
            parameters.Add(p => p.Margin, margin);

            if (onValueChange.HasValue)
            {
                parameters.Add(p => p.OnValueChange, onValueChange.Value);
            }
           
            if (fetchActionType != null)
            {
                parameters.AddCascadingValue("FetchActionType", fetchActionType);
            }

        });

        return render;
    }
        
}
