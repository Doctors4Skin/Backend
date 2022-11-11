using Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _service;
    public PatientsController(IPatientService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllPatients());
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]PatientRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }
        return Ok(await _service.CreatePatient(request));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.GetPatientById(id);
        return response.Success ? Ok(response) : NotFound(response);
    }
}
