namespace MyOrder.Shared.Dtos;

public abstract record MyOrderContextResponse(
    bool? Success,
    string? Message,
    string? ErrorCause)
{
    public override string ToString() => $"Success: {Success}, Message: {Message}, ErrorCause: {ErrorCause}";
}