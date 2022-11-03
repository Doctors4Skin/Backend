using AutoMapper;
using Doctor4skin.Dto.Request;
using Doctor4skin.Dto.Response;
using Doctors4skin.Entities;

namespace Doctor4skin.Services.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<DoctorRequest, Doctor>();

        CreateMap<Doctor, DoctorResponse>()
            .ForMember(d => d.Id, o => o.MapFrom(resp => resp.Id))
            .ForMember(d => d.Name, o => o.MapFrom(resp => resp.Name))
            .ForMember(d => d.Age, o => o.MapFrom(resp => resp.Age))
            .ForMember(d => d.PhotoUrl, o => o.MapFrom(resp => resp.PhotoUrl))
            .ForMember(d => d.Description, o => o.MapFrom(resp => resp.Description))
            .ForMember(d => d.Qualification, o => o.MapFrom(resp => resp.Qualification));
    }
}
