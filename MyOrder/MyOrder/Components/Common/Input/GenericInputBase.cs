using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Utils;

namespace MyOrder.Components.Common.Input;
public abstract class GenericInputBase<TValue> : ComponentBase
{
    protected bool hidden;
    protected bool readWrite;
    protected bool required;
    protected bool onlyForDisplay;

    [Parameter] public bool? ReadOnly { get; set; } = null;
    [Parameter, EditorRequired] public TValue? BoundValue { get; set; }
    [Parameter, EditorRequired] public Field<TValue>? Field { get; set; }
    [Parameter] public EventCallback<TValue> BoundValueChanged { get; set; }
    protected async Task BoundValueChangedHandler() => await BoundValueChanged.InvokeAsync(BoundValue);

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        hidden = FieldUtility.IsHidden(Field);
        ReadOnly = ReadOnly ?? FieldUtility.IsReadOnly(Field);
        readWrite = FieldUtility.IsReadWrite(Field);
        required = FieldUtility.IsRequired(Field);
        onlyForDisplay = FieldUtility.IsOnlyForDisplay(Field);

    }
}

