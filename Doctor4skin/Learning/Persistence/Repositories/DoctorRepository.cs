using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Domain.Repositories;
using Doctor4skin.Learning.Persistence.Contexts;
using Doctor4skin.Learning.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doctor4skin.Learning.Persistence.Repositories;

public class DoctorRepository : BaseRepository, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context) { }

    public async Task AddAsync(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
    }

    public async Task<Doctor?> FindByIdAsync(int id)
    {
        return await _context.Doctors.FindAsync(id);    
    }

    public async Task<IEnumerable<Doctor>> ListAsync()
    {
        return await _context.Doctors.ToListAsync();
    }

    public void Remove(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
    }

    public void update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
    }
}
