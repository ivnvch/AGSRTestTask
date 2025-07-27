using AGSRTestTask.Application.Abstractions;

namespace AGSRTestTask.Persistence.Data;

public class UnitOfWork:IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
     return _context.SaveChangesAsync(cancellationToken);
    }
}