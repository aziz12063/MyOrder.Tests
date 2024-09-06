using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Utils;

namespace MyOrder.Components.Common.Input;
public abstract class GenericInputBase<T> : ComponentBase
{

    protected bool hidden;
    protected bool readOnly;
    protected bool readWrite;
    protected bool required;
    protected bool onlyForDisplay;

    [Parameter, EditorRequired] public T? BoundValue { get; set; }
    [Parameter, EditorRequired] public Field<T>? Field { get; set; }
    [Parameter] public EventCallback<T> BoundValueChanged { get; set; }
    protected async Task BoundValueChangedHandler() => await BoundValueChanged.InvokeAsync(BoundValue);

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        hidden = FieldUtility.IsHidden(Field);
        readOnly = FieldUtility.IsReadOnly(Field);
        readWrite = FieldUtility.IsReadWrite(Field);
        required = FieldUtility.IsRequired(Field);
        onlyForDisplay = FieldUtility.IsOnlyForDisplay(Field);
    }
}

