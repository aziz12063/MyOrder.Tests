using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Store.ReloadUseCase;

namespace MyOrder.Components.Common;

public sealed class ShortcutEventsComponent : ComponentBase, IAsyncDisposable
{

    [Inject] IDispatcher Dispatcher { get; set; } = null!;
    [Inject] IJSRuntime JSRuntime { get; set; } = null!;
    [Inject] ILogger<ShortcutEventsComponent> Logger { get; set; } = null!;
    [Inject] IEventAggregator EventAggregator { get; set; } = null!;
    [Inject] IState<GlobalOperationsState> GlobalOperationsState { get; set; } = null!;

    private DotNetObjectReference<ShortcutEventsComponent>? _dotNetHelper;
    private bool _handlersRegistered = false;

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    _dotNetHelper = DotNetObjectReference.Create(this);
    //    await JSRuntime.InvokeVoidAsync("registerCtrlIHandler", _dotNetHelper);
    //    await JSRuntime.InvokeVoidAsync("registerF5Handler", _dotNetHelper);
    //    Logger.LogDebug("F5EventComponent initialized");
    //}

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Create the DotNetObjectReference once
            _dotNetHelper = DotNetObjectReference.Create(this);

            try
            {
                // Register both handlers just this one time
                await JSRuntime.InvokeVoidAsync("registerCtrlIHandler", _dotNetHelper);
                await JSRuntime.InvokeVoidAsync("registerF5Handler", _dotNetHelper);
                _handlersRegistered = true;
                Logger.LogDebug("ShortcutEventsComponent: JS handlers registered.");
            }
            catch (JSException jsEx)
            {
                // If JS functions "registerCtrlIHandler" / "registerF5Handler" are missing,
                // we’ll catch here and log so that we don’t silently leak.
                Logger.LogError(jsEx, "Failed to register JS handlers for shortcuts.");
            }
        }
    }


    [JSInvokable("F5Pressed")]
    public void F5Pressed()
    {
        if (!GlobalOperationsState.Value.IsAppReloading && !GlobalOperationsState.Value.IsGlobalBlocked)
        {
            Dispatcher.Dispatch(new ReloadAction());
            Logger.LogDebug("F5 pressed and action dispatched.");
        }
        else
        {
#warning Implement a user-friendly notification
            Logger.LogDebug("F5 pressed but app is reloading or global operations are blocked.");
        }
    }

    [JSInvokable("CtrlIPressed")]
    public async Task CtrlIPressed()
    {
        Logger.LogDebug("CtrlIPressed called");
        await EventAggregator.PublishAsync(new ShortcutTriggeredEvent(Shortcut.CtrlI));
    }

    public async ValueTask DisposeAsync()
    {
        if (_handlersRegistered && _dotNetHelper != null)
        {
            await JSRuntime.InvokeVoidAsync("unregisterCtrlIHandler").AsTask();
            await JSRuntime.InvokeVoidAsync("unregisterF5Handler").AsTask();

            // Dispose the .NET reference
            _dotNetHelper.Dispose();
            _dotNetHelper = null;

            Logger.LogDebug("ShortcutEventsComponent: JS handlers unregistered, _dotNetHelper disposed.");
        }
    }
}
