using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using Radzen;

namespace MyOrder.Components.Childs.Lines
{
    public partial class AddLines //: ComponentBase
    {
        public LineDto lineItem = new LineDto();

        //[Parameter]
        //public Action<LineDto> LinesAddedCallback { get; set; }
        [Parameter]
        public EventCallback<LineDto> LineAddedCallback { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        void AddLine()
        {
            LineAddedCallback.InvokeAsync(lineItem);
            DialogService.Close();
        }

        void Cancel()
        {
            DialogService.Close(null);
        }
    }
}
