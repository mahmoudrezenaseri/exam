using Exam.Framework.ApplicationService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Framework.Mvc
{
    public abstract class ExamController : ControllerBase
    {
        protected IMediator mediator => (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
        protected IActionResult HandleApplicationServiceResult<TData>(ApplicationServiceResult<TData> result)
        {
            switch (result.Status)
            {
                case ApplicationServiceResultStatus.ValidationError:
                    return BadRequest(result);

                case ApplicationServiceResultStatus.Notfound:
                    return NotFound(result);

                case ApplicationServiceResultStatus.Exception:
                    return StatusCode(500, result);

                case ApplicationServiceResultStatus.Ok:
                default:
                    return Ok(result);
            }
        }
    }
}
