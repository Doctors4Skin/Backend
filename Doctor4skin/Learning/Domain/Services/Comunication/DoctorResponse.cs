using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Shared.Domain.Services.Comunication;

namespace Doctor4skin.Learning.Domain.Services.Comunication;

public class DoctorResponse : BaseResponse<Doctor>
{
    public DoctorResponse(string message) : base(message) { }
    public DoctorResponse(Doctor resource) : base(resource) { }
}
