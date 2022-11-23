using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Domain.Repositories;
using Doctor4skin.Learning.Domain.Services;
using Doctor4skin.Learning.Domain.Services.Comunication;
using System.Diagnostics;

namespace Doctor4skin.Learning.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IDoctorRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DoctorResponse> DeleteAsync(int id)
    {
        var existingDoctor = await _repository.FindByIdAsync(id);

        if (existingDoctor == null)
            return new DoctorResponse("Docton not found");

        try
        {
            _repository.Remove(existingDoctor);
            await _unitOfWork.CompleteAsync();
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception ex)
        {
            return new DoctorResponse($"An error ocurred while deleting the patient : {ex.Message}");
        }
    }

    public async Task<IEnumerable<Doctor>> ListAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task<DoctorResponse> SaveAsync(Doctor doctor)
    {
        try
        {
            await _repository.AddAsync(doctor);
            await _unitOfWork.CompleteAsync();
            return new DoctorResponse(doctor);
        }
        catch (Exception ex)
        {
            return new DoctorResponse($"An error ocurrer while saving the doctor : {ex.Message}");
        }
    }

    public async Task<DoctorResponse> UpdateAsync(int id, Doctor doctor)
    {
        var existingDoctor = await _repository.FindByIdAsync(id);
        if (existingDoctor == null)
            return new DoctorResponse("Doctor not found");
        existingDoctor.Workplace = doctor.Workplace;
        existingDoctor.Qualification = doctor.Qualification;
        existingDoctor.Description = doctor.Description;
        existingDoctor.Email = doctor.Email;
        existingDoctor.Age = doctor.Age;
        existingDoctor.Name = doctor.Name;
        existingDoctor.Speciality = doctor.Speciality;
        existingDoctor.PhotoUrl = doctor.PhotoUrl;
        existingDoctor.Password = doctor.Password;
        try
        {
            _repository.update(existingDoctor);
            await _unitOfWork.CompleteAsync();
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception ex)
        {
            return new DoctorResponse($"An error ocurred while updating the tutorial : {ex.Message}");
        }
    }
}
