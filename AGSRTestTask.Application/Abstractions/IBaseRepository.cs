using System.Linq.Expressions;
using AGSRTestTask.Domain.Entities;

namespace AGSRTestTask.Application.Abstractions;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity,  CancellationToken cancellationToken);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);

    Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
}