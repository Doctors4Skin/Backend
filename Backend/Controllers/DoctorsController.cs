using Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _service;
    public DoctorsController(IDoctorService service)
    {
        _service = service;
    }   
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllDoctors());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.GetDoctorById(id);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DoctorRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }
        return Ok(await _service.CreateDoctor(request));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] DoctorRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(request);
        return Ok(await _service.UpdateDoctor(id, request));
    }
}
