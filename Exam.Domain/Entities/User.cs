﻿namespace Exam.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}
