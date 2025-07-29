using AGSRTestTask.Application.Patients.Commands;
using AGSRTestTask.Application.Patients.Commands.Create;
using AGSRTestTask.Application.Patients.Commands.Delete;
using AGSRTestTask.Application.Patients.Commands.Update;
using AGSRTestTask.Application.Patients.Models.Requests;
using AGSRTestTask.Application.Patients.Models.Responses;
using AGSRTestTask.Application.Patients.Queries;
using AGSRTestTask.Domain.Result;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AGSRTestTask.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// End-point на создание объекта Patient
    /// </summary>
    /// <param name="request">Модель Patient</param>
    /// <returns>Объект Patient</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<CreatePatientResponse>>> CreatePatient([FromBody] CreatePatientRequest request)
    {
        CreatePatientCommand model = new CreatePatientCommand
               (request.Gender,
                request.DateOfBirth,
                request.Active,
                request.LastName,
                request.FirstName,
                request.MiddleName,
                request.Use
                );
        var response = await _mediator.Send(model);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// End-point на удаление объекта Patient из БД
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<bool>>> DeletePatient([FromBody] DeletePatientCommand model)
    {
        var response = await _mediator.Send(model);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// End-point на обновление объекта Patient
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Обновлённый объект Patient</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<UpdatePatientResponse>>> Update([FromBody] UpdatePatientRequest request)
    {
        UpdatePatientCommand model = new UpdatePatientCommand
        (request.PatientId,
            request.Gender,
            request.DateOfBirth,
            request.Active,
            request.LastName,
            request.FirstName,
            request.MiddleName,
            request.Use
        );
        var response = await _mediator.Send(model);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<GetPatientResponse>>> GetPatient([FromRoute] GetPatientRequest request)
    {
        
        var response = await _mediator.Send(new GetPatientQuery(PatientId : request.PatientId));
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        
        return BadRequest(response);
    }
    
}