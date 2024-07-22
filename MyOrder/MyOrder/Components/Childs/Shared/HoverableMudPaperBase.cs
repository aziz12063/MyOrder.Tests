using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MyOrder.Components.Childs.Shared
{
    public class HoverableMudPaperBase : MudPaper
    {
        [Parameter] public int HoverElevation { get; set; } = 4;
        protected int currentElevation;

        protected override void OnInitialized()
        {
            currentElevation = Elevation;
        }

        protected void MouseEnterHandler()
        {
            currentElevation = HoverElevation;
        }

        protected void MouseLeaveHandler()
        {
            currentElevation = Elevation;
        }
    }
}
