using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

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
    protected TValue? ValueProperty => Field.Value;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Inject]
    protected ILogger<GenericInputBase<TValue>> Logger { get; set; }
    [Inject]
    protected IDispatcher Dispatcher { get; set; }
    [CascadingParameter(Name = "FetchActionType")]
    protected Type SelfFetchAction { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Parameter, EditorRequired]
    public required Field<TValue> Field { get; set; }
    [Parameter]
    public bool? ReadOnly { get; set; } = null;
    [Parameter]
    public bool HideLabel { get; set; } = false;
    [Parameter]
    public Margin Margin { get; set; } = Margin.Dense;
    [Parameter]
    public EventCallback OnValueChange { get; set; }

    protected virtual async void ValueChangedHandler(TValue newValue)
    {
        Dispatcher.Dispatch(new UpdateFieldAction(Field, newValue, SelfFetchAction));
        await OnValueChange.InvokeAsync(ValueProperty);
    }


    protected override void OnInitialized()
    {
        base.OnInitialized();
        ArgumentNullException.ThrowIfNull(SelfFetchAction,
            $"{nameof(SelfFetchAction)} for the following component {typeof(Field<TValue>)} ({Field?.Name})");
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Field == null)
            return;

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
        // CR> 17/04/2025 Provoque un bogue à la mise à jour de la donnée
        format == "P" || format == "p" ? "0.##" : format;
        //format == "P" || format == "p" ? "0.## '%'" : format;

}

