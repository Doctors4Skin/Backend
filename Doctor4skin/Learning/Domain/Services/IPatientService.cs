using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Domain.Services.Comunication;

namespace Doctor4skin.Learning.Domain.Services;

public interface IPatientService
{
    Task<IEnumerable<Patient>> ListAsync();
    Task<Patient?> GetByIdAsync(int id);
    Task<PatientResponse> SaveAsync(Patient patient);
    Task<PatientResponse> UpdateAsync(int id, Patient patient);
    Task<PatientResponse> DeleteAsync(int id);
}
