using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Components.Childs.Shared
{
    public abstract class LoadableComponent : ComponentBase
    {
        private readonly IBasketRepository? _basketRepository;

        [Inject]
        public IBasketRepository BasketRepository
        {
            get => _basketRepository ?? throw new Exception("Couldn't retrieve the injected property"); 
            init => _basketRepository = value;
        }

        protected bool IsLoading { get; private set; } = true;
        protected string ErrorMessage { get; private set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                throw;
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
