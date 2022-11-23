using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Doctor4skin.Learning.Domain.Services;
using Doctor4skin.Learning.Resources;
using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Shared.Extensions;

namespace Doctor4skin.Learning.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PatientController : ControllerBase
{
    private readonly IPatientService _service;
    private readonly IMapper _mapper;

    public PatientController(IPatientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<PatientResource>> GetAllAsync()
    {
        var patients = await _service.ListAsync();  
        var resources = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientResource>>(patients);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePatientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var patient = _mapper.Map<SavePatientResource, Patient>(resource);

        var result = await _service.SaveAsync(patient);

        if (!result.Success)
            return BadRequest(result.Message);

        var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);

        return Ok(patientResource);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var patient = await _service.GetByIdAsync(id);
        var patientResource = _mapper.Map<Patient, PatientResource>(patient);
        return Ok(patientResource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        return Ok(new { message = "Patient deleted successfully" });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePatientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var patient = _mapper.Map<SavePatientResource, Patient>(resource);

        var result = await _service.UpdateAsync(id, patient);

        if (!result.Success)
            return BadRequest(result.Message);

        var patientResource = _mapper.Map<Patient, PatientResource>(patient);

        return Ok(patientResource);
    }
}
