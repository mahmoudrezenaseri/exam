namespace Exam.API.Controllers;

using Exam.Application.Features.Users.Commands;
using Exam.Application.Features.Users.Queries;
using Exam.Domain.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<UserItem>> GetAllUsers()
    {
        return await this.mediator.Send(new GetAllUsersQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserItem>> GetUser(Guid id)
    {
        var user = await this.mediator.Send(new GetUserByIdQuery(id));

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        try
        {
            var user = await this.mediator.Send(command);

            if (user is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        try
        {
            var user = await this.mediator.Send(command);

            if (user is null)
            {
                return BadRequest();
            }

            return this.NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
