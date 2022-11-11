using AutoMapper;
using Dto.Request;
using Dto.Response;
using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using System.Runtime.CompilerServices;

namespace Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DoctorService(IDoctorRepository repository, ILogger logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<BaseResponseGeneric<int>> CreateDoctor(DoctorRequest request)
    {
        var response = new BaseResponseGeneric<int>();
        try
        {
            var entity = _mapper.Map<Doctor>(request);
            response.Data = await _repository.CreateDoctor(entity);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            _logger.LogCritical(ex, "Error al insertar un Doctor {message}", ex.Message);
        }
        return response;
    }
    public async Task<BaseResponseGeneric<List<DoctorResponse>>> GetAllDoctors()
    {
        var response = new BaseResponseGeneric<List<DoctorResponse>>();
        try
        {
            var data = await _repository.GetAllDoctors();
            response.Data = _mapper.Map<List<DoctorResponse>>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            _logger.LogCritical(ex, "Error en el servicio de Listar a los Doctores {message}", ex.Message);
            response.Success = false;
        }
        return response;
    }
    public async Task<BaseResponseGeneric<DoctorResponse>> GetDoctorById(int id)
    {
        var response = new BaseResponseGeneric<DoctorResponse>();
        try
        {
            var data = await _repository.GetDoctorById(id);
            response.Data = _mapper.Map<DoctorResponse>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            _logger.LogCritical(ex, "Error al obtener Doctor {message}", ex.Message);
        }
        return response;
    }
    public async Task<BaseResponse> UpdateDoctor(int id, DoctorRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var entity = await _repository.GetDoctorById(id);
            if(entity == null)
            {
                response.Success = false;
                return response;
            }
            _mapper.Map(request, entity);
            await _repository.UpdateDoctor();
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            _logger.LogCritical(ex, "Error al actualizar Doctor {message}", ex.Message);
        }
        return response;
    }
}