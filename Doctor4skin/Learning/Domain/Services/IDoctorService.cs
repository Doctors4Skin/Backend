using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Domain.Services.Comunication;
using Doctor4skin.Shared.Domain.Services.Comunication;

namespace Doctor4skin.Learning.Domain.Services;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task<Doctor?> GetByIdAsync(int id);
    Task<DoctorResponse> SaveAsync(Doctor doctor);
    Task<DoctorResponse> UpdateAsync(int id, Doctor doctor);
    Task<DoctorResponse> DeleteAsync(int id);
}
