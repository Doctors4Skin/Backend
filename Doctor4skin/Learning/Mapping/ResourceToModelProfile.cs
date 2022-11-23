using AutoMapper;
using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Resources;

namespace Doctor4skin.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDoctorResource, Doctor>();
        CreateMap<SavePatientResource, Patient>();
    }
}
