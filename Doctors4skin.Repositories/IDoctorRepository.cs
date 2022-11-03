using Doctors4skin.Entities;

namespace Doctors4skin.Repositories;

public interface IDoctorRepository
{
    List<Doctor> GetAll();
    Doctor? FindByLogin(string email, string password);
    Doctor? GetById(int id);
    void UpadteDoctor(int id, Doctor doctor);
}
