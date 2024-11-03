using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Collections.Immutable;

namespace MyOrder.Store.ProcedureCallUseCase;

public class UpdateFieldAction(IField field, dynamic? value, Type selfActionType)
{
    public IField Field { get; } = field;
    public dynamic? Value { get; } = value;
    public Type SelfFetchActionType { get; } = selfActionType;
}

public class PostProcedureCallSuccessAction(string basketId, ProcedureCallResponseDto procedureCallResponse)
{
    public ProcedureCallResponseDto ProcedureCallResponse { get; set; } = procedureCallResponse;
    public string BasketId { get; } = basketId;
}

public class PostProcedureCallFailureAction(Type actionType, string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
    public Type SelfFetchActionType { get; } = actionType;
}

public class FetchValidationRulesAction(ImmutableList<string> procedureCall, string basketId)
{
    public ImmutableList<string> ProcedureCall { get; } = procedureCall;
    public string BasketId { get; set; } = basketId;
}

public class FetchValidationRulesFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
