using Fluxor;
using MyOrder.Components.Layout;

namespace MyOrder.Store.AdminUseCase
{
    [FeatureState]
    public class AdminState
    {
        public string Name { get; set; }
        public Adminlayout Component { get; set; }
        public Type CurrentComponent { get; private set; }
        public Dictionary<string, object> Parameters { get; }

        public AdminState(Type currentComponent, Dictionary<string, object> parameters)
        {
            CurrentComponent = currentComponent;
            Parameters = parameters ?? new Dictionary<string, object>();
        }

        public AdminState(string name)
        {
            Name = name;
        }

        public AdminState(Adminlayout component)
        {
            Component = component;
        }

        public AdminState()
        {
            Name = string.Empty;
            Parameters = new Dictionary<string, object>();
        }
    }
}
