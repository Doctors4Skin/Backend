using AutoMapper;
using Dto.Request;
using Dto.Response;
using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using System.Runtime.CompilerServices;

namespace Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository repository, ILogger logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<BaseResponseGeneric<List<PatientResponse>>> GetAllPatients()
    {
        var response = new BaseResponseGeneric<List<PatientResponse>>();
        try
        {
            var data = await _repository.GetAllPatients();
            response.Data = _mapper.Map<List<PatientResponse>>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            _logger.LogCritical(ex, "Erro en el servicio de obtener los Pacientes {message}", ex.Message);
        }
        return response;
    }
    public async Task<BaseResponseGeneric<PatientResponse>> GetPatientById(int id)
    {
        var response = new BaseResponseGeneric<PatientResponse>();
        try
        {
            var data = await _repository.GetPatientById(id);
            response.Data = _mapper.Map<PatientResponse>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            _logger.LogCritical(ex, "Error en el servicio de obtener un paciente {message}", ex.Message);
        }
        return response;
    }
    public async Task<BaseResponseGeneric<int>> CreatePatient(PatientRequest request)
    {
        var response = new BaseResponseGeneric<int>();
        try
        {
            var entity = _mapper.Map<Patient>(request);
            response.Data = await _repository.CreatePatient(entity);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            _logger.LogCritical(ex, "Error en el servicio de crear Paciente {message}", ex.Message);
        }
        return response;
    }
}
