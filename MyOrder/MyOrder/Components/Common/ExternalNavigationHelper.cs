using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using MyOrder.Store.GlobalOperationsUseCase;

namespace MyOrder.Components.Common
{
    public class ExternalNavigationHelper : ComponentBase, IAsyncDisposable
    {
        [Inject] private IJSRuntime JS { get; set; } = null!;
        [Inject] private IState<ExternalNavigationState> ExternalNavigationState { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private ILogger<ExternalNavigationHelper> Logger { get; set; } = null!;

        private readonly CancellationTokenSource _cts = new();
        private bool _isNavigating = false;
        private bool _unsubscribedStateChanged = false;
        private bool _unsubscribedLocationChanged = false;
        private bool _promptVisible = false;

        protected override void OnInitialized()
        {
            ExternalNavigationState.StateChanged += OpenLink;
            NavigationManager.LocationChanged += OnLocationChanged;
            base.OnInitialized();
        }

        private async void OpenLink(object? sender, EventArgs e)
        {
            if (_isNavigating)
                return;

            var target = ExternalNavigationState.Value.Target ?? "";
            var url = ExternalNavigationState.Value.Url ?? "";

            if (string.IsNullOrWhiteSpace(url))
                return;

            try
            {
                if (target.Contains("self", StringComparison.OrdinalIgnoreCase))
                {
                    _isNavigating = true;
                    NavigationManager.NavigateTo(url, forceLoad: true);
                }

                if (!_cts.IsCancellationRequested)
                {
                    bool opened;
                    try
                    {
                        opened = await JS.InvokeAsync<bool>(
                            "tryOpenLink",
                            _cts.Token,
                            url,
                            target
                        );
                    }
                    catch (TaskCanceledException)
                    {
                        Logger.LogDebug("OpenLink aborted: navigation is already in progress.");
                        return;
                    }
                    catch (JSException jsEx)
                    {
                        Logger.LogError(jsEx, "JS_Invoke of tryOpenLink failed in OpenLink.");
                        _promptVisible = true;
                        await InvokeAsync(StateHasChanged);
                        return;
                    }

                    if (!opened)
                    {
                        _promptVisible = true;
                        await InvokeAsync(StateHasChanged);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Unexpected error in OpenLink.");
            }
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs args)
        {
            if (!_unsubscribedStateChanged)
            {
                ExternalNavigationState.StateChanged -= OpenLink;
                _unsubscribedStateChanged = true;
            }

            _isNavigating = true;

            if (!_cts.IsCancellationRequested)
                _cts.Cancel();

            if (!_unsubscribedLocationChanged)
            {
                NavigationManager.LocationChanged -= OnLocationChanged;
                _unsubscribedLocationChanged = true;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!_unsubscribedStateChanged)
            {
                ExternalNavigationState.StateChanged -= OpenLink;
                _unsubscribedStateChanged = true;
            }

            if (!_unsubscribedLocationChanged)
            {
                NavigationManager.LocationChanged -= OnLocationChanged;
                _unsubscribedLocationChanged = true;
            }

            if (!_cts.IsCancellationRequested)
                _cts.Cancel();

            _cts.Dispose();

            await Task.CompletedTask;
        }
    }
}
