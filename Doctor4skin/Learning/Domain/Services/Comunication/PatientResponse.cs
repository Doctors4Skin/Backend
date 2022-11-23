using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Shared.Domain.Services.Comunication;

namespace Doctor4skin.Learning.Domain.Services.Comunication;

public class PatientResponse : BaseResponse<Patient>
{
    public PatientResponse(string message) : base(message) { }
    public PatientResponse(Patient resource) : base(resource) { }
}
