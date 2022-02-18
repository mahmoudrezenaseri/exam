using Exam.Core.ApplicationService.Common;
using FluentValidation;

namespace Exam.Core.ApplicationService.Users.Commands.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.NationalCode).Must(natinalCode => CommonValidation.NationalCodeIsValid(natinalCode));
            RuleFor(x => x.PhoneNumber).Must(phoneNumber => CommonValidation.PhoneNumberIsValid(phoneNumber));
        }
    }
}
