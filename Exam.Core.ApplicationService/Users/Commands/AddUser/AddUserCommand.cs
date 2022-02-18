using Exam.Core.ApplicationService.Users.ViewModels;
using Exam.Framework.ApplicationService;
using System.Collections.Generic;

namespace Exam.Core.ApplicationService.Users.Commands.AddUser
{
    public class AddUserCommand : ICommand<UserViewModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
