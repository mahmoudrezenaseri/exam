namespace Exam.Application.Features.Users.Queries;

using Exam.Domain.Dtos;
using MediatR;

public record GetUserByIdQuery (Guid Id) : IRequest<UserItem?>;
