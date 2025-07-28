using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface ICommand<out TResponse>: IRequest<TResponse>
{
}