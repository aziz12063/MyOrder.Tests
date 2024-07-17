namespace MyOrder.Store.AdminUseCase
{
    public class LoadComponentAction
    {
        public Type ComponentType { get; }
        public Dictionary<string, object> Parameters { get; }
        public LoadComponentAction(Type componentType, Dictionary<string, object> parameters)
        {
            ComponentType = componentType;
            Parameters = parameters;
        }
    }
}
