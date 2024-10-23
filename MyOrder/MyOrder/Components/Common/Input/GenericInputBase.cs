using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;
using System.Reflection.Emit;

namespace MyOrder.Components.Common.Input;
public abstract class GenericInputBase<TValue> : ComponentBase
{
    protected bool Hidden { get; set; }
    protected bool InternalReadOnly { get; set; }
    protected bool ReadWrite { get; set; }
    protected bool Required { get; set; }
    protected bool OnlyForDisplay { get; set; }
    protected bool Error { get; set; }
    protected string? TooltipText { get; set; }
    protected TValue? ValueProperty { get; set; }

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

    protected void OnBindValueAfter() =>
        Dispatcher.Dispatch(new UpdateFieldAction(Field, ValueProperty, SelfFetchAction));

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        if (Field == null)
            return;

        ValueProperty = Field.Value;
        Hidden = FieldUtility.IsHidden(Field);
        InternalReadOnly = ReadOnly ?? FieldUtility.IsReadOnly(Field);
        ReadWrite = FieldUtility.IsReadWrite(Field);
        Required = FieldUtility.IsRequired(Field);
        OnlyForDisplay = FieldUtility.IsOnlyForDisplay(Field);
        TooltipText = Field.Description ?? Field.Name;
        Error = !string.IsNullOrWhiteSpace(Field!.Error);
    }

    protected string? FieldLabel() => HideLabel ? null : Field!.Name;
    protected static string? FormatPercentValue(string? format) =>
        format == "P" || format == "p" ? "0.## '%'" : format;

}

