namespace Exam.Application.Features.Users.Handlers;

using AutoMapper;
using Exam.Application.Features.Users.Commands;
using Exam.Application.Features.Users.Validators;
using Exam.Domain.Dtos;
using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserItem?>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserItem?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = this.mapper.Map<User>(request);
        var result = await this.repository.UpdateUser(user);

        if (result is null)
        {
            return null;
        }

        return this.mapper.Map<UserItem>(result);
    }
}
