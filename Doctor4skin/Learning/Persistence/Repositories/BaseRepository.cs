using System;
using Doctor4skin.Learning.Persistence.Contexts;

namespace Doctor4skin.Learning.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}