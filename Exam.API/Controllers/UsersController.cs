using Exam.Core.ApplicationService.Users.Commands.AddUser;
using Exam.Core.ApplicationService.Users.Commands.UpdateUser;
using Exam.Core.ApplicationService.Users.Queries.GetUserById;
using Exam.Framework.ApplicationService;
using Exam.Framework.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class UsersController : ExamController
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var query = new GetUserByIdQuery()
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return HandleApplicationServiceResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUserCommand command)
        {
            var result = await mediator.Send(command);
            return HandleApplicationServiceResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            command.Id = id;
            var result = await mediator.Send(command);
            return HandleApplicationServiceResult(result);
        }
    }
}
