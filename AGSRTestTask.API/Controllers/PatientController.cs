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
public class PatientController : BaseController
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// End-point на создание объекта Patient
    /// </summary>
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
                request.Use);
        
        var response = await _mediator.Send(model);

        return Result(response);
    }

    /// <summary>
    /// End-point на удаление объекта Patient из БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<bool>>> DeletePatient([FromRoute] Guid id)=>
        Result(await _mediator.Send(new DeletePatientCommand(id)));
    
    /// <summary>
    /// End-point на обновление объекта Patient
    /// </summary>
    /// <returns>Обновлённый объект Patient</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<UpdatePatientResponse>>> Update([FromRoute] Guid id, [FromBody] UpdatePatientRequest request)
    {
        UpdatePatientCommand model = new UpdatePatientCommand
           (id,
            request.Gender,
            request.DateOfBirth,
            request.Active,
            request.LastName,
            request.FirstName,
            request.MiddleName,
            request.Use);
        
        var response = await _mediator.Send(model);
        
        return Result(response);
    }

    /// <summary>
    /// End-point на получение объекта Patient
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetPatient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<GetPatientResponse>>> GetPatient([FromQuery] GetPatientRequest  request) =>
        Result(await _mediator.Send(new GetPatientQuery(request.PatientId)));
    
    /// <summary>
    /// Создает несколько объектов Patient одним пакетом.
    /// </summary>
    /// <returns>Результат пакетного создания.</returns>
    [HttpPost("batch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<IEnumerable<Guid>>>> CreatePatientsBatch([FromBody] CreatePatientListCommand request)=>
        Result(await _mediator.Send(request));
    
    /// <summary>
    /// Поиск по дате рождения с фильтрами (eq, ne, gt и т.д.).
    /// </summary>
    /// <returns></returns>
    [HttpGet("searchByBirthDate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<List<GetPatientResponse>>>> SearchByBirthDate([FromQuery] List<string> birthDateFilters)
    {
        var query = new SearchPatientsByBirthDateQuery(BirthDateFilters: birthDateFilters);

        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
}