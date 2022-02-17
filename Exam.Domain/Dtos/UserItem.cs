namespace Exam.Domain.Dtos;

public record UserItem
(
    Guid Id,
    string FirstName,
    string LastName,
    string NationalCode,
    string PhoneNumber
);
