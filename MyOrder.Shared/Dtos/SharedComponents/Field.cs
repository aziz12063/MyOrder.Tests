namespace MyOrder.Shared.Dtos.SharedComponents;

public class Field<T>
{
    public string? Name { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public T? Value { get; set; }
    public List<string?>? ProcedureCall { get; set; }
    public string? Error { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
}
