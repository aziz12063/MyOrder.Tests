using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Store.ProcedureCallUseCase
{
    public class UpdateFieldAction(IField field, dynamic value)
    {
        public IField Field { get; } = field;
        public dynamic Value { get; } = value;
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
