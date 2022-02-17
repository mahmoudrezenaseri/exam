namespace Exam.Application.Features.Users.Handlers;

using AutoMapper;
using Exam.Application.Features.Users.Commands;
using Exam.Application.Features.Users.Queries;
using Exam.Domain.Dtos;
using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserItem>>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public GetAllUsersQueryHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<UserItem>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users =  await this.repository.GetAllUsers();
        return this.mapper.Map<List<UserItem>>(users);
    }
}
