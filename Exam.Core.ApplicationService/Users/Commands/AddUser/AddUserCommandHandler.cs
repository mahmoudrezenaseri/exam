using Exam.Core.ApplicationService.Users.ViewModels;
using Exam.Core.Domain.Users.Contracts;
using Exam.Core.Domain.Users.Entities;
using Exam.Framework.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Core.ApplicationService.Users.Commands.AddUser
{
    public class AddUserCommandHandler : CommandHandler<AddUserCommand, UserViewModel>
    {
        private readonly IUserCommandRepository userCommandRepository;

        public AddUserCommandHandler(IServiceProvider serviceProvider, IUserCommandRepository userCommandRepository)
            :base(serviceProvider)
        {
            this.userCommandRepository = userCommandRepository;
        }
        public override async Task<ApplicationServiceResult<UserViewModel>> HandleCommand(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = Mapper.Map<User>(request);

            user.Id = await userCommandRepository.UserAdd(user);

            var data = Mapper.Map<UserViewModel>(user);

            return Ok(data);
        }
    }
}
