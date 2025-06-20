namespace MyOrder.Shared.Dtos.GeneralInformation;

public record BasketHistory(
    string? Name,
    string? Url,
    bool? IsCurrent);