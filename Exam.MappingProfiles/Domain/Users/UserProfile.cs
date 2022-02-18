using AutoMapper;
using Exam.Core.ApplicationService.Users.Commands.AddUser;
using Exam.Core.ApplicationService.Users.Commands.UpdateUser;
using Exam.Core.ApplicationService.Users.ViewModels;
using Exam.Core.Domain.Users.Entities;

namespace Exam.MappingProfiles.Domain.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
