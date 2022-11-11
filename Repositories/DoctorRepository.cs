using DataAccess;
using Dto.Response;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly Doctor4SkinDbContext _context;

    public DoctorRepository(Doctor4SkinDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateDoctor(Doctor doctor)
    {
        await _context.Set<Doctor>().AddAsync(doctor);
        await _context.SaveChangesAsync();
        return doctor.Id;
    }

/*    public async Task DeleteDoctor(Doctor doctor)
    {
        _context.Set<Doctor>().Remove(doctor);
        await _context.SaveChangesAsync();
    }*/

    public async Task<List<Doctor>> GetAllDoctors()
    {
        return await _context.Set<Doctor>().ToListAsync();
    }

    public async Task<Doctor?> GetDoctorById(int id)
    {
        return await _context.Set<Doctor>().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task UpdateDoctor()
    {
        await _context.SaveChangesAsync();
    }
}