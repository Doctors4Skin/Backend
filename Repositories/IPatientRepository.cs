using Entities;

namespace Repositories;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllPatients();
    Task<Patient?> GetPatientById(int id);
    Task<int> CreatePatient(Patient patient);
 
}
