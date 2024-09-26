using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.Base;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Common.Input;
public abstract class GenericInputBase<TValue> : ComponentBase
{
    protected bool _hidden;
    protected bool _readOnly;
    protected bool _readWrite;
    protected bool _required;
    protected bool _onlyForDisplay;
    protected string? _tooltipText;

    [Inject]
    protected IDispatcher Dispatcher { get; set; }
    [CascadingParameter(Name = "FetchActionType")]
    private Type SelfFetchAction { get; set; }
    [Parameter]
    public bool? ReadOnly { get; set; } = null;
    [Parameter, EditorRequired]
    public Field<TValue>? Field { get; set; }

    protected TValue? ValueProperty { get; set; }
    

    protected void BoundValueChangedHandler() =>        
        Dispatcher.Dispatch(new UpdateFieldAction(Field, ValueProperty, SelfFetchAction));

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Field == null)
            return;

        ValueProperty = Field.Value;
        _hidden = FieldUtility.IsHidden(Field);
        _readOnly = ReadOnly ?? FieldUtility.IsReadOnly(Field);
        _readWrite = FieldUtility.IsReadWrite(Field);
        _required = FieldUtility.IsRequired(Field);
        _onlyForDisplay = FieldUtility.IsOnlyForDisplay(Field);
        _tooltipText = Field.Description ?? Field.Name;
    }

}

