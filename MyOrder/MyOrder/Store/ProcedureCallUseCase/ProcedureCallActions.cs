using MyOrder.Shared.Dtos;

namespace MyOrder.Store.ProcedureCallUseCase
{
    public class PostProcedureCallAction(string basketId, List<string> procedureCall)
    {
        public List<string> ProcedureCall { get; } = procedureCall;
        public string BasketId { get; } = basketId;
    }
    public class PostProcedureCallSuccessAction(string basketId, ProcedureCallResponseDto procedureCallResponse)
    {
        public ProcedureCallResponseDto ProcedureCallResponse { get; set; } = procedureCallResponse;
        public string BasketId { get; } = basketId;
    }

    public class PostProcedureCallFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
