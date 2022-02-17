namespace Exam.Application.Features.Users.Queries;

using Exam.Domain.Dtos;
using MediatR;

public record GetAllUsersQuery () : IRequest<List<UserItem>>;
