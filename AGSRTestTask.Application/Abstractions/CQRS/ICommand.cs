using AGSRTestTask.Domain.Result;
using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface ICommand<TResponse>: IRequest<BaseResult<TResponse>>
{
}

public interface ICommandList<TResponse>: IRequest<CollectionResult<TResponse>>
{
}