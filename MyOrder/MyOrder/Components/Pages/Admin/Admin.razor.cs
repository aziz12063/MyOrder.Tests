using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Layout;
using MyOrder.Store.AdminUseCase;

namespace MyOrder.Components.Pages.Admin
{
    public partial class Admin
    {
        [Inject]
        IDispatcher Dispatcher { get; set; }
        [Inject]
        IState<AdminState> ComponentState { get; set; }

        public string MyName { get; set; }

        private Type currentComponent;

        private IDictionary<string, object> currentParameters;

        private void LoadComponent(Type componentType)
        {
            currentComponent = componentType;
            currentParameters = new Dictionary<string, object>(); // Add any parameters if needed
        }
        protected override void OnInitialized()
        {
            Dispatcher.Dispatch(new LoadComponentAction(typeof(General), null));
            MyName = this.GetType().Name;
            Console.WriteLine("my name is " + MyName);
            Dispatcher.Dispatch(new UpdateNameAction(MyName));
            currentComponent = typeof(General);
        }
    }
}

