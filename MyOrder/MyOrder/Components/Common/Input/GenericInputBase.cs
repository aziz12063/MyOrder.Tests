using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;
using System.Reflection.Emit;

namespace MyOrder.Components.Common.Input;
public abstract class GenericInputBase<TValue> : ComponentBase
{
    protected bool _hidden;
    protected bool _readOnly;
    protected bool _readWrite;
    protected bool _required;
    protected bool _onlyForDisplay;
    protected bool _error;
    protected string? _tooltipText;

    private TValue? _valueProperty;

    [Inject]
    protected IDispatcher Dispatcher { get; set; }
    [Inject]
    protected ILogger<GenericInputBase<TValue>> Logger { get; set; }
    [CascadingParameter(Name = "FetchActionType")]
    private Type SelfFetchAction { get; set; }
    [Parameter]
    public bool? ReadOnly { get; set; } = null;
    [Parameter, EditorRequired]
    public Field<TValue> Field { get; set; }
    [Parameter]
    public bool HideLabel { get; set; } = false;

    protected TValue? ValueProperty { get; set; }

    // Direct handler of the input value change
    protected void OnBindValueAfter() =>
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
        _error = !string.IsNullOrWhiteSpace(Field!.Error);
    }

    protected string? FieldLabel() => HideLabel ? null : Field!.Name;
    protected static string? FormatPercentValue(string? format) =>
        format == "P" || format == "p" ? "0.## '%'" : format;

}

