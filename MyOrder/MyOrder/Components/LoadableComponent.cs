using Microsoft.AspNetCore.Components;

namespace MyOrder.Components
{
    public abstract class LoadableComponent : ComponentBase
    {
        protected bool IsLoading { get; private set; } = true;
        protected string ErrorMessage { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
            await base.OnInitializedAsync();
        }

        protected abstract Task LoadDataAsync();
    }
}
