using AGSRTestTask.Domain.Result;
using MediatR;

namespace AGSRTestTask.Application.Abstractions.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, BaseResult<TResponse>> where TQuery : IQuery<TResponse>
{
    
}