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

public class PostProcedureCallSuccessAction(ProcedureCallResponseDto procedureCallResponse)
{
    public ProcedureCallResponseDto ProcedureCallResponse { get; set; } = procedureCallResponse;
}

public class UpdateFieldProcedureCallFailureAction(Type actionType, string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
    public Type SelfFetchActionType { get; } = actionType;
}

public class PostProcedureCallAction(ImmutableList<string?>? procedureCall)
{
    public ImmutableList<string?>? ProcedureCall { get; } = procedureCall;
}

public class PostProcedureCallFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
