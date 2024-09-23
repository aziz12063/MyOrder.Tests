namespace MyOrder.Shared.Dtos;

public record BasketValueDto(string? Description, string? Value)
{
    public override string ToString() => Description
        ?? Value
        ?? string.Empty;
}