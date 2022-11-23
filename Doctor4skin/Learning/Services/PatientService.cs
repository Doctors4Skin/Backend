using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Domain.Repositories;
using Doctor4skin.Learning.Domain.Services;
using Doctor4skin.Learning.Domain.Services.Comunication;


namespace Doctor4skin.Learning.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IPatientRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<PatientResponse> DeleteAsync(int id)
    {
        var existingPatient = await _repository.FindByIdAsync(id);
        if (existingPatient == null)
            return new PatientResponse("Patient not found");
        try
        {
            _repository.Remove(existingPatient);
            await _unitOfWork.CompleteAsync();
            return new PatientResponse(existingPatient);
        }
        catch (Exception ex)
        {
            return new PatientResponse($"An error ocurred while deleting the patient : {ex.Message}");
        }
    }

    public async Task<IEnumerable<Patient>> ListAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<Patient?> GetByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task<PatientResponse> SaveAsync(Patient patient)
    {
        try
        {
            await _repository.AddAsync(patient);
            await _unitOfWork.CompleteAsync();
            return new PatientResponse(patient);    
        }
        catch (Exception ex)
        {
            return new PatientResponse($"An error ocurred while saving the tutorial: {ex.Message}");
        }
    }

    public async Task<PatientResponse> UpdateAsync(int id, Patient patient)
    {
        var existingPatient = await _repository.FindByIdAsync(id);
        if (existingPatient == null)
            return new PatientResponse("Patient not found.");
        existingPatient.Email = patient.Email;
        existingPatient.Age = patient.Age;
        existingPatient.PhotoUrl = patient.PhotoUrl;
        existingPatient.Name = patient.Name;
        existingPatient.Password = patient.Password;
        try
        {
            _repository.Update(existingPatient);
            await _unitOfWork.CompleteAsync();
            return new PatientResponse(existingPatient);
        }
        catch (Exception ex)
        {
            return new PatientResponse($"An error ocurred while updating the tutorial: {ex.Message}");
        }
    }
}
