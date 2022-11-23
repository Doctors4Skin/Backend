using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Domain.Repositories;
using Doctor4skin.Learning.Persistence.Contexts;
using Doctor4skin.Learning.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doctor4skin.Learning.Persistence.Repositories;

public class PatientRepository : BaseRepository, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context) { }
    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
    }

    public async Task<Patient?> FindByIdAsync(int id)
    {
        return await _context.Patients.FindAsync(id);   
    }

    public async Task<IEnumerable<Patient>> ListAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public void Remove(Patient patient)
    {
        _context.Patients.Remove(patient);
    }

    public void Update(Patient patient)
    {
        _context.Patients.Update(patient);
    }
}
