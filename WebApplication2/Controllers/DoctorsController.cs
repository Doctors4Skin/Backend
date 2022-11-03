using Doctor4skin.Dto.Request;
using Doctor4skin.Dto.Response;
using Doctor4skin.Services;

using Microsoft.AspNetCore.Mvc;
namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController
{
    private readonly IDoctorService _service;
    public DoctorsController(IDoctorService service)
    {
        _service = service;
    }
    [HttpGet]
    public BaseResponseGeneric<List<DoctorResponse>> Get()
    {
        return _service.GetAll();
    }
    [HttpGet("{id:int}")]
    public BaseResponseGeneric<DoctorResponse> Get(int id)
    {
        var response = _service.GetById(id);
        return response;
    }
    [HttpGet("loggin")]
    public BaseResponseGeneric<DoctorResponse> FindByLogin(string email, string password)
    {
        return _service.FindByLogin(email, password);
    }
    [HttpPut("{id:int}")]
    public BaseResponse UpdateDoctor(int id, [FromBody] DoctorRequest request)
    {
        return _service.UpdateDoctor(id, request); 
    }
}
