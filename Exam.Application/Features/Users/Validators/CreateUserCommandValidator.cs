namespace Exam.Application.Features.Users.Validators;

using Exam.Application.Features.Users.Commands;
using FluentValidation;
using PhoneNumbers;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(64);

        // National code validation
        RuleFor(x => x.NationalCode).Custom((code, context) =>
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                context.AddFailure("National code can't be empty");
            }

            if (code.Length != 10)
            {
                context.AddFailure("National code should be 10 digits");
            }

            if (!code.All(char.IsDigit))
            {
                context.AddFailure("National code can only contain numeric values");
            }
        });

        // Phone number validation
        RuleFor(x => x.PhoneNumber).Custom((phone, context) =>
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                context.AddFailure("Phone number can't be empty");
            }

            if (phone.StartsWith("00"))
            {
                phone = $"+{phone[2..]}";
            }

            var phoneUtil = PhoneNumberUtil.GetInstance();

            try
            {
                var phoneNumber = phoneUtil.Parse(phone, "IR");

                if (!phoneUtil.IsValidNumber(phoneNumber))
                {
                    context.AddFailure("Phone number is invalid");
                }
            }
            catch (NumberParseException)
            {
                context.AddFailure("Phone number is invalid");
            }
        });
    }
}
