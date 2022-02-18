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

namespace Exam.Core.ApplicationService.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : CommandHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IUserCommandRepository userCommandRepository;

        public UpdateUserCommandHandler(IServiceProvider serviceProvider, IUserCommandRepository userCommandRepository)
            : base(serviceProvider)
        {
            this.userCommandRepository = userCommandRepository;
        }
        public override async Task<ApplicationServiceResult<UserViewModel>> HandleCommand(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var findedUser = await userCommandRepository.UserGetById(request.Id);
            if (findedUser == null)
                return NotFound();

            findedUser = Mapper.Map<UpdateUserCommand, User>(request, findedUser);

            await userCommandRepository.UserUpdate(findedUser);

            var data = Mapper.Map<UserViewModel>(findedUser);

            return Ok(data);
        }
    }
}
