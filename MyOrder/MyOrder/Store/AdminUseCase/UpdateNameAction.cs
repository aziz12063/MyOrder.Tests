using MyOrder.Components.Layout;

namespace MyOrder.Store.AdminUseCase
{
    
    public class UpdateNameAction
    {
        public string NewName { get; set; }
        public UpdateNameAction(string newName)
        {
            NewName = newName;
        }
    }

    public class InitializeComponentAction
    {
        public Adminlayout Component { get; set; }

        public InitializeComponentAction(Adminlayout component)
        {
            Component = component;
        }
    }
}
