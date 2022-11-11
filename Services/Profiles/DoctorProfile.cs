using AutoMapper;
using Dto.Request;
using Dto.Response;
using Entities;

namespace Services.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<DoctorRequest, Doctor>();
        CreateMap<Doctor, DoctorResponse>();
    }
}
