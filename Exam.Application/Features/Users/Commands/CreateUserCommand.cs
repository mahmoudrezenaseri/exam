namespace Exam.Application.Features.Users.Commands;

using Exam.Domain.Dtos;
using MediatR;

public record CreateUserCommand
(
    string FirstName,
    string LastName,
    string NationalCode,
    string PhoneNumber
) : IRequest<UserItem?>;
