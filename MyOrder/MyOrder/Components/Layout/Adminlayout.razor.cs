using Fluxor.Blazor.Web.Components;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Store.AdminUseCase;
using MyOrder.Components.Pages.Admin;


namespace MyOrder.Components.Layout
{
    public partial class Adminlayout
    {
        private bool sidebar1Expanded = true;
        public string Name;
        private Type currentComponentType;

        [Inject]
        IState<AdminState> State { get; set; }

        [Inject]
        IDispatcher Dispatcher { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }  


        protected override void OnInitialized()
        {
            
            Name = State.Value.Name;
            Console.WriteLine("the name is " + Name);
            Dispatcher.Dispatch(new InitializeComponentAction(this));
          
        }
        public void OpenComponent(Type componentType)
        {
           

            Dispatcher.Dispatch(new LoadComponentAction(componentType, null));
            // update this method to /Admin it's the generate page
            //NavigationManager.NavigateTo("/general");
        }

        
        


    }
}
