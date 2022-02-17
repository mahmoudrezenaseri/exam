namespace Exam.Application.Features.Users.Mapping;

using AutoMapper;
using Exam.Application.Features.Users.Commands;
using Exam.Domain.Dtos;
using Exam.Domain.Entities;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserItem>();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
    }
}
