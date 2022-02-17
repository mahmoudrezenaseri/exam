namespace Exam.Application.Features.Users.Handlers;

using AutoMapper;
using Exam.Application.Features.Users.Queries;
using Exam.Domain.Dtos;
using Exam.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserItem?>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserItem?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await this.repository.GetUserById(request.Id);
        return this.mapper.Map<UserItem>(user);
    }
}
