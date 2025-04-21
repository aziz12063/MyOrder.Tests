namespace MyOrder.Shared.Dtos;

public record ApiErrorResponseDto(ApiError Error);

public record ApiError(
    int Code,
    string Reason,
    string Message);