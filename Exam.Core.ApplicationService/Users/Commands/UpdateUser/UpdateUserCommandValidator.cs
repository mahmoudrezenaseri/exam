using Exam.Core.ApplicationService.Common;
using FluentValidation;

namespace Exam.Core.ApplicationService.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.NationalCode).Must(natinalCode => CommonValidation.NationalCodeIsValid(natinalCode));
            RuleFor(x => x.PhoneNumber).Must(phoneNumber => CommonValidation.PhoneNumberIsValid(phoneNumber));
        }
    }
}
