using Doctor4skin.Learning.Domain.Models;

namespace Doctor4skin.Learning.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task AddAsync(Doctor doctor);
    Task<Doctor?> FindByIdAsync(int id);
    void update(Doctor doctor);
    void Remove(Doctor doctor); 
}

