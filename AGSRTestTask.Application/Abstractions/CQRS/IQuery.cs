using AGSRTestTask.Domain.Result;
using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<BaseResult<TResponse>>
{
    
}