using AGSRTestTask.Application.Patients.Commands;
using AGSRTestTask.Application.Patients.Commands.Create;
using AGSRTestTask.Application.Patients.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AGSRTestTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreatePatientRequest>> CreatePatient([FromBody] CreatePatientCommand model)
    {
        var response = await _mediator.Send(model); 
        
        return Ok(response);
    }
}