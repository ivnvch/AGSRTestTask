using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface ICommandHandler<in TCommand, TResponse>:IRequestHandler<TCommand, TResponse> where TCommand: ICommand<TResponse>
{
}