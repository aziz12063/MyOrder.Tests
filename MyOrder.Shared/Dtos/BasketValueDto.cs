
namespace MyOrder.Shared.Dtos;

public class BasketValueDto
{
    public string? Description { get; set; }
    public string? Value { get; set; }

    public override string ToString() => Description ?? string.Empty;
}

