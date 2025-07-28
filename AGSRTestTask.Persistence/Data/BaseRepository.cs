using System.Linq.Expressions;
using AGSRTestTask.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AGSRTestTask.Persistence.Data;

public abstract class BaseRepository<T>: IBaseRepository<T> where T : class
{
    private readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity,  CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task<T> UpdateAsync(T entity,  CancellationToken cancellationToken)
    { 
        _context.Set<T>().Update(entity);
        return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken)
    { 
        _context.Set<T>().Remove(entity);
        return await Task.FromResult(true);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }
}