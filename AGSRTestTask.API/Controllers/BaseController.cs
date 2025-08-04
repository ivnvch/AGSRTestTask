using AGSRTestTask.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace AGSRTestTask.Controllers;

/// <summary>
/// Базовый контроллер с общими методами для возврата результата.
/// </summary>
public abstract class BaseController : ControllerBase
{
   protected ActionResult<BaseResult<T>> Result<T>(BaseResult<T> response) =>
      response.IsSuccess ? Ok(response) : BadRequest(response);

   protected ActionResult<BaseResult> Result(BaseResult response) =>
      response.IsSuccess ? Ok(response) : BadRequest(response);
}