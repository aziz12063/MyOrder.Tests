using System.Collections.Immutable;

namespace MyOrder.Shared.Dtos.SharedComponents;

public record Field<T>(
    string? Name,
    T? Value,
    string? Description,
    string? Status,
    string? Error,
    string Color,
    string? Confirm,
    ImmutableList<string?>? ProcedureCall,
    bool? IsBlockingProcedure,
    string? Url,
    FieldDisplayStyle? DisplayStyle) : IField;