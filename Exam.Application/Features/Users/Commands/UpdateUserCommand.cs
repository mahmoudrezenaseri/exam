namespace Exam.Application.Features.Users.Commands;

using Exam.Domain.Dtos;
using MediatR;

public record UpdateUserCommand
(
    Guid Id,
    string FirstName,
    string LastName,
    string NationalCode,
    string PhoneNumber
) : IRequest<UserItem?>;
