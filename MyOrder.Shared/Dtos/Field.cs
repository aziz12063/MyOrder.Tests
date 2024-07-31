namespace MyOrder.Shared.Dtos;

public class Field<T>
{
    public string? Name { get; set; } = string.Empty;
    public string? Status { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;
    public T? Value { get; set; }
    public List<string>? ProcedureCall { get; set; } = [];
    public string? Error { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? Url { get; set; } = string.Empty;
}
