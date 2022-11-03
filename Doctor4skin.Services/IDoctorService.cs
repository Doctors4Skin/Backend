using Doctor4skin.Dto.Request;
using Doctor4skin.Dto.Response;

namespace Doctor4skin.Services;

public interface IDoctorService
{
    BaseResponseGeneric<List<DoctorResponse>> GetAll();
    BaseResponseGeneric<DoctorResponse> FindByLogin(string email, string password);
    BaseResponseGeneric<DoctorResponse> GetById(int id);
    BaseResponse UpdateDoctor(int id, DoctorRequest request);
}