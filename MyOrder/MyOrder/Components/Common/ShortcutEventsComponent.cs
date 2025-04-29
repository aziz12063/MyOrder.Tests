using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.ReloadUseCase;

namespace MyOrder.Components.Common;

public sealed class ShortcutEventsComponent : ComponentBase, IDisposable
{

    [Inject] IDispatcher Dispatcher { get; set; } = null!;
    [Inject] IJSRuntime JSRuntime { get; set; } = null!;
    [Inject] ILogger<ShortcutEventsComponent> Logger { get; set; } = null!;
    [Inject] IEventAggregator EventAggregator { get; set; } = null!;

    private DotNetObjectReference<ShortcutEventsComponent>? _dotNetHelper;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        _dotNetHelper = DotNetObjectReference.Create(this);
        await JSRuntime.InvokeVoidAsync("registerCtrlIHandler", _dotNetHelper);
        await JSRuntime.InvokeVoidAsync("registerF5Handler", _dotNetHelper);
        Logger.LogDebug("F5EventComponent initialized");
    }

    [JSInvokable("F5Pressed")]
    public void F5Pressed()
    {
        //TODO: Show a message to the user that the page is being refreshed, with a result of the action
        Dispatcher.Dispatch(new ReloadAction());
        Logger.LogDebug("F5 pressed and action dispatched.");
    }

    [JSInvokable("CtrlIPressed")]
    public async Task CtrlIPressed()
    {
        Logger.LogDebug("CtrlIPressed called");
        await EventAggregator.PublishAsync(new ShortcutTriggeredEvent(Shortcut.CtrlI));
    }

    public void Dispose()
    {
        if (_dotNetHelper != null)
        {
            _dotNetHelper.Dispose();
            _dotNetHelper = null;
            Logger.LogDebug("_dotNetHelper disposed and set to null in Dispose()");
        }
    }
}
