using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MyOrder.Components.Common.UI
{
    public class HoverableMudPaperBase : MudPaper
    {
        [Parameter] public int HoverElevation { get; set; } = 4;
        [Parameter] public int IdleElevation { get; set; } = 2;
        protected int currentElevation;

        protected override void OnInitialized()
        {
            currentElevation = IdleElevation;
        }

        protected void MouseEnterHandler()
        {
            currentElevation = HoverElevation;
        }

        protected void MouseLeaveHandler()
        {
            currentElevation = IdleElevation;
        }
    }
}
