using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Doctor4skin.Learning.Domain.Services;
using Doctor4skin.Learning.Resources;
using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Doctor4skin.Learning.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _service;
    private readonly IMapper _mapper;

    public DoctorController(IDoctorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DoctorResource>> GetAllAsync()
    {
        var doctors = await _service.ListAsync();
        var resource = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDoctorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var doctor = _mapper.Map<SaveDoctorResource, Doctor>(resource);

        var result = await _service.SaveAsync(doctor);

        if (!result.Success)
            return BadRequest(result.Message);

        var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);

        return Ok(doctorResource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var doctor = await _service.GetByIdAsync(id);
        var doctorResource = _mapper.Map<Doctor, DoctorResource>(doctor);
        return Ok(doctorResource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        return Ok(new { message = "Doctor deleted successfully" });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDoctorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var doctor = _mapper.Map<SaveDoctorResource, Doctor>(resource);

        var result = await _service.UpdateAsync(id, doctor);

        if (!result.Success)
            return BadRequest(result.Message);

        var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);

        return Ok(doctorResource);
    }
}
