using Dto.Request;
using Dto.Response;

namespace Services;

public interface IDoctorService
{
    Task<BaseResponseGeneric<List<DoctorResponse>>> GetAllDoctors();
    Task<BaseResponseGeneric<int>> CreateDoctor(DoctorRequest request);
    Task<BaseResponseGeneric<DoctorResponse>> GetDoctorById(int id);
    Task<BaseResponse> UpdateDoctor(int id, DoctorRequest request);
}
