using AutoMapper;
using Dto.Request;
using Dto.Response;
using Entities;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<PatientRequest, Patient>();
        CreateMap<Patient, PatientResponse>();
    }
}
