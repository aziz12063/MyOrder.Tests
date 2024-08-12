
namespace MyOrder.Shared.Dtos;

public class ProcedureCallResponseDto : MyOrderContextResponse
{
    public bool? UpdateDone { get; set; }
    public List<string?>? RefreshCalls { get; set; }
}

