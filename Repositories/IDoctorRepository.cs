using Entities;

namespace Repositories;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllDoctors();
    Task<int> CreateDoctor(Doctor doctor);
    Task<Doctor?> GetDoctorById(int id);
    Task UpdateDoctor();
/*    Task DeleteDoctor(Doctor doctor);*/
}
