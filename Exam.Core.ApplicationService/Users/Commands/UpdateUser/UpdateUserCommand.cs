using Exam.Core.ApplicationService.Users.ViewModels;
using Exam.Framework.ApplicationService;

namespace Exam.Core.ApplicationService.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : ICommand<UserViewModel>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
