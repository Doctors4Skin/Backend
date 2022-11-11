using Dto.Request;
using Dto.Response;

namespace Services;

public interface IPatientService
{
    Task<BaseResponseGeneric<List<PatientResponse>>> GetAllPatients();
    Task<BaseResponseGeneric<PatientResponse>> GetPatientById(int id);
    Task<BaseResponseGeneric<int>> CreatePatient(PatientRequest request);
}
