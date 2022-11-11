using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly Doctor4SkinDbContext _context;

    public PatientRepository(Doctor4SkinDbContext context)
    {
        _context = context;
    }   
    public async Task<List<Patient>> GetAllPatients()
    {
        return await _context.Set<Patient>().ToListAsync();
    }
    public async Task<Patient?> GetPatientById(int id)
    {
        return await _context.Set<Patient>().FirstOrDefaultAsync(x => x.Id == id);  
    }
    public async Task<int> CreatePatient(Patient patient)
    {
        await _context.Set<Patient>().AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient.Id;
    }
}
