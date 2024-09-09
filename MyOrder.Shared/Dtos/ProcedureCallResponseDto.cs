
namespace MyOrder.Shared.Dtos;

public class ProcedureCallResponseDto : MyOrderContextResponse
{
    public bool? UpdateDone { get; set; }
    public List<string?>? RefreshCalls { get; set; }

    public override string ToString() => base.ToString() 
        + $"\nUpdateDone: {UpdateDone}, " +
        $"RefreshCalls: {string.Join("\n", RefreshCalls ?? [])}";
}

