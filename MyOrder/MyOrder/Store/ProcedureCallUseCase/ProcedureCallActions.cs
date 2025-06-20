using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Collections.Immutable;

namespace MyOrder.Store.ProcedureCallUseCase;

public record UpdateFieldAction(IField Field, dynamic? Value, Type SelfFetchActionType);

public record PostProcedureCallCompletedSuccessfullyAction(ProcedureCallResponseDto ProcedureCallResponse);

public record UpdateFieldProcedureCallFailureAction(Type SelfFetchActionType, string ErrorMessage);

public record PostProcedureCallAction(ImmutableList<string?>? ProcedureCall);

public record PostProcedureCallFailureAction(string ErrorMessage);
