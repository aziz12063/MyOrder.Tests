using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOrder.Components.Childs.Lines
{
    public partial class Lines : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        private List<LineDto> lines = new List<LineDto>();

        [Inject]
        protected DialogService DialogService { get; set; }
        RadzenDataGrid<LineDto> grid = new();

        private async Task AddLine()
        {
            //await DialogService.OpenAsync<AddLines>("Add Line");
            await DialogService.OpenAsync<AddLines>("Add Line", new Dictionary<string, object>()
            {
                { "LineAddedCallback", EventCallback.Factory.Create<LineDto>(this, OnLineAdded) }
            });

        }

        private void OnLineAdded(LineDto newLine)
        {
            newLine.Ligne = lines.Count + 1; // Set the line number or other default values
            lines.Add(newLine);
            grid.Reload();
            Console.WriteLine("nbr of line = " + lines.Count.ToString());
            StateHasChanged(); // Ensure UI updates

        }

        private void OnDeleteLineClick()
        {
            // Handle Delete Line button click event
            Console.WriteLine("Delete Line button clicked");
        }
    }
}


