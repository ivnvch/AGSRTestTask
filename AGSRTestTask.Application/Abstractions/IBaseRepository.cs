using System.Linq.Expressions;

namespace AGSRTestTask.Application.Abstractions;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity,  CancellationToken cancellationToken);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);

    Task<T> GetAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
}