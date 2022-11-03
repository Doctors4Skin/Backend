using AutoMapper;
using Doctor4skin.Dto.Request;
using Doctor4skin.Dto.Response;
using Doctors4skin.Repositories;
//using Microsoft.Extensions.Logging;

namespace Doctor4skin.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;
    //private readonly ILogger _logger;
    
    public DoctorService(IDoctorRepository repository, IMapper mapper/*, ILogger logger*/)
    {
        _repository = repository;
        _mapper = mapper;
        //_logger = logger;
    }
    public BaseResponseGeneric<List<DoctorResponse>> GetAll()
    {
        var response = new BaseResponseGeneric<List<DoctorResponse>>();
        try
        {
            var data = _repository.GetAll();
            response.Data = _mapper.Map<List<DoctorResponse>>(data);
            response.Success = true;
        }
        catch(Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            //_logger.LogCritical(ex, "Error en el servicio de listar los Doctores {mesagge}", ex.Message);
        }
        return response;
    }
    public BaseResponseGeneric<DoctorResponse> FindByLogin(string email, string password)
    {
        var response = new BaseResponseGeneric<DoctorResponse>();

        try
        {
            var data = _repository.FindByLogin(email, password);
            response.Data = _mapper.Map<DoctorResponse>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            //_logger.LogCritical(ex, "Error en el servicio de loggear Doctor {message}", ex.Message);
        }

        return response;
    }
    public BaseResponseGeneric<DoctorResponse> GetById(int id)
    {
        var response = new BaseResponseGeneric<DoctorResponse>();
        try
        {
            var data = _repository.GetById(id);
            response.Data = _mapper.Map<DoctorResponse>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            //_logger.LogCritical(ex, "Error en el servicio de obtener un Doctor {message}", ex.Message);
        }
        return response;
    }
    public BaseResponse UpdateDoctor(int id, DoctorRequest request)
    {
        var response = new BaseResponse();

        try
        {
            var doctor = _repository.GetById(id);
            if(doctor == null)
            {
                response.Success = false;
                return response;
            }

            _repository.UpadteDoctor(id, _mapper.Map(request, doctor));

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.Success = false;
            //_logger.LogCritical(ex, "Error en el servicio de actualizar Doctor {message}", ex.Message);
        }

        return response;
    }

}
