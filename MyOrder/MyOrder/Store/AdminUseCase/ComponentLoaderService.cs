namespace MyOrder.Store.AdminUseCase
{
    public class ComponentLoaderService
    {
        public event Action<Type> OnComponentChange;

        public void LoadComponent(Type componentType)
        {
            OnComponentChange?.Invoke(componentType);
        }
    }

}
