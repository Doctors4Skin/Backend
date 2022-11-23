using Doctor4skin.Learning.Domain.Repositories;
using Doctor4skin.Learning.Persistence.Contexts;

namespace Doctor4skin.Learning.Leraning.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}