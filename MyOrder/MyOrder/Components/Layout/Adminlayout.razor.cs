using Microsoft.AspNetCore.Components;


namespace MyOrder.Components.Layout
{
    public partial class Adminlayout
    {
        private bool sidebar1Expanded = true;
        public string Name;
        private Type currentComponentType;

       
        [Inject]
        NavigationManager NavigationManager { get; set; }  


        protected override void OnInitialized()
        {
            
           
            Console.WriteLine("the name is " + Name);
           
          
        }
        public void OpenComponent(Type componentType)
        {
           

           
            // update this method to /Admin it's the generate page
            //NavigationManager.NavigateTo("/general");
        }

        
        


    }
}
