using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Ackee.AspNetCore;
using DomainModel;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : AckeeApiController
{
    private readonly IUserRepository _repository;
    private readonly ExamDbContext _examDbContext;

    public UserController(IUserRepository repository, ExamDbContext examDbContext)
    {
        _repository = repository;
        _examDbContext = examDbContext;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserModel model)
    {
        var userId = UserId.CreateNew();
        var nationalCode = new NationalCode(model.NationalCode);
        var user = new User(userId,
            model.FirstName, model.LastName, nationalCode, model.PhoneNumber);

        await _repository.Create(user);
        await _examDbContext.SaveChangesAsync();
        return Ok(userId.DbId);
    }

    [HttpPatch]
    public async Task<ActionResult<Guid>> Update(Guid id, CreateUserModel model)
    {
        var user = await _repository.Get(UserId.CreateNew(id));
        if (user is null)
            throw new Exception("User Not Found");

        var nationalCode = new NationalCode(model.NationalCode);
        user.Update(model.FirstName, model.LastName, nationalCode, model.PhoneNumber);


        await _examDbContext.SaveChangesAsync();
        return Ok(user);
    }
    [HttpGet]
    public async Task<ActionResult<Guid>> Update(Guid id)
    {
        var user = await _repository.Get(UserId.CreateNew(id));
        if (user is null)
            throw new Exception("User Not Found");

        return Ok(user);
    }
}