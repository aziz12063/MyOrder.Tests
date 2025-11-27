using AngleSharp.Dom;
using Bunit;
using MudBlazor;
using MyOrder.Components.Common.Input;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.UnitTesting.GenericInput;

public class GenericMudSelectTests : GenericInputTestBase
{
    [Fact]
    public void Render_Should_Display_Items_And_Label()
    {
        // Arrange
        var item = new BasketValueDto("1", "Item One");
        var field = new Field<BasketValueDto?>("Test", item, null, null, null, "red", null, null, null, null, null);
       

        var items = new List<BasketValueDto>
        {
            item           
        };

        // Act
        var cut = RenderInputComponent<GenericMudSelect<BasketValueDto>, BasketValueDto?>(
            field: field,
            fetchActionType: typeof(UpdateFieldAction),  // mandatory for SelfFetchAction
            items: items
        );

        // Assert: the label is rendered
        cut.MarkupMatches(@$"
<div>
  <div class=""mud-tooltip-root"" style=""width:100%"">
    <div class=""mud-select-input-control"">
      <label>{field.Name}</label>
    </div>
  </div>
</div>");
    }
}
