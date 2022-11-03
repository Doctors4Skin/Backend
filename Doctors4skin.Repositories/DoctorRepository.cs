using Doctors4skin.Entities;

namespace Doctors4skin.Repositories;

public class DoctorRepository: IDoctorRepository
{
    private readonly List<Doctor> _doctors;
    public DoctorRepository()
    {
        _doctors = new List<Doctor>();
        for(int i = 0; i < 10; i++)
        {
            this._doctors.Add(new Doctor 
                { 
                    Id = i,
                    Name = "Nombre" + Convert.ToString(i + 1),
                    Age = 25 + i,
                    Description = "",
                    Workplace = "Hospital" + Convert.ToString(i + 1),
                    Speciality = "Cirujano",
                    Qualification = 0,
                    Email = "email" + Convert.ToString(i + 1) + "@gmail.com",
                    Password = "password" + Convert.ToString(i + 1)
            });
        }
    }
    public List<Doctor> GetAll()
    {
        return _doctors;
    }
    public Doctor? FindByLogin(string email, string password)
    {
        return _doctors.Find(d => d.Email == email && d.Password == password);
    }
    public Doctor? GetById(int id)
    {
        return _doctors.Find(d => d.Id == id);
    }
    public void UpadteDoctor(int id, Doctor doctor)
    {
        var element = _doctors.FirstOrDefault(d => d.Id == doctor.Id);
        _doctors.Remove(element);
        _doctors.Add(doctor);
    }

}
