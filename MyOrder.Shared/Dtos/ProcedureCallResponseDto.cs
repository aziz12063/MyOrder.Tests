
namespace MyOrder.Shared.Dtos;

public record ProcedureCallResponseDto(
    bool? UpdateDone,
    List<string?>? RefreshCalls,
    ProcedureCallUrlDto? Target,
    bool? Success,
    string? Message,
    string? ErrorCause)
    : MyOrderContextResponse(
        Success,
        Message,
        ErrorCause)
{
    public override string ToString() => base.ToString()
        + $"\nUpdateDone: {UpdateDone}, " +
        $"RefreshCalls: {string.Join("\n", RefreshCalls ?? [])}\n" +
        $"Target: {Target?.TargetUrl}";
}