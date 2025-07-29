using AGSRTestTask.Domain.Result;
using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface ICommandHandler<in TCommand, TResponse>:IRequestHandler<TCommand, BaseResult<TResponse>> where TCommand: ICommand<TResponse>
{
}