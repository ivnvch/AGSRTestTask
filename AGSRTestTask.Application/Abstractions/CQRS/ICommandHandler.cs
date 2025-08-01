using AGSRTestTask.Domain.Result;
using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface ICommandHandler<in TCommand, TResponse>:IRequestHandler<TCommand, BaseResult<TResponse>> where TCommand: ICommand<TResponse>
{
}

public interface ICommandListHandler<in TCommand, TResponse> :
    IRequestHandler<TCommand, CollectionResult<TResponse>> where TCommand:
    ICommandList<TResponse>
{
}