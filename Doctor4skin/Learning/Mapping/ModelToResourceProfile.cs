using AutoMapper;
using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Learning.Resources;

namespace Doctor4skin.Learning.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Doctor, DoctorResource>();
        CreateMap<Patient, PatientResource>();
    }
}
