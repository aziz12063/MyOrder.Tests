using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Utils;

namespace MyOrder.Components.Common.Input;
public abstract class GenericInputBase<TValue> : ComponentBase
{
    protected bool _hidden;
    protected bool _readOnly;
    protected bool _readWrite;
    protected bool _required;
    protected bool _onlyForDisplay;

    [Parameter] public bool? ReadOnly { get; set; } = null;
    [Parameter, EditorRequired] public TValue? BoundValue { get; set; }
    [Parameter, EditorRequired] public Field<TValue>? Field { get; set; }
    [Parameter] public EventCallback<TValue> BoundValueChanged { get; set; }
    protected async Task BoundValueChangedHandler() =>
        await BoundValueChanged.InvokeAsync(BoundValue);

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _hidden = FieldUtility.IsHidden(Field);
        _readOnly = ReadOnly ?? FieldUtility.IsReadOnly(Field);
        _readWrite = FieldUtility.IsReadWrite(Field);
        _required = FieldUtility.IsRequired(Field);
        _onlyForDisplay = FieldUtility.IsOnlyForDisplay(Field);

    }
}

