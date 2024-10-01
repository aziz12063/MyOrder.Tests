namespace MyOrder.Shared.Dtos;

public abstract class MyOrderContextResponse
{
    public bool? Success { get; set; }
    public string? Message { get; set; }
    public string? ErrorCause { get; set; }

    override public string ToString() => $"Success: {Success}, Message: {Message}, ErrorCause: {ErrorCause}";
}

