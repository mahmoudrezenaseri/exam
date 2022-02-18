using Exam.Core.ApplicationService.Users.ViewModels;
using Exam.Core.Domain.Users.Contracts;
using Exam.Framework.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Core.ApplicationService.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<UserViewModel>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdQueryHandler : QueryHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserQueryRepository userQueryRepository;

        public GetUserByIdQueryHandler(IServiceProvider serviceProvider, IUserQueryRepository userQueryRepository)
            : base(serviceProvider)
        {
            this.userQueryRepository = userQueryRepository;
        }
        public override async Task<ApplicationServiceResult<UserViewModel>> HandleCommand(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var findedUser = await userQueryRepository.UserGetById(request.Id);
            if (findedUser == null)
                return NotFound();

            var data = Mapper.Map<UserViewModel>(findedUser);

            return Ok(data);
        }
    }
}
