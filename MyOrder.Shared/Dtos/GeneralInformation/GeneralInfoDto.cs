namespace MyOrder.Shared.Dtos.GeneralInformation;

public record GeneralInfoDto(
    string? PageTitle,
    BasketCompany? Company,
    string? OrderType,
    string? BasketId,
    string? OrderId,
    string? OrderStatus,
    DateTime? OrderDate,
    string? SalesResponsible,
    BasketActions? Actions);