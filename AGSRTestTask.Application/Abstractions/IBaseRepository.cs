using System.Linq.Expressions;

namespace AGSRTestTask.Application.Abstractions;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T> GetAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
}