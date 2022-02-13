using Ackee.Domain.Model;

namespace DomainModel;

public class User : AggregateRoot<UserId>
{
    protected User()
    {
    }

    public User(UserId userId, string firstName,
        string lastName,
        NationalCode nationalCode,
        string phoneNumber)
    {
        Id = userId;

        SetProperties(firstName, lastName, nationalCode, phoneNumber);
    }

    private void SetProperties(string firstName, string lastName, NationalCode nationalCode, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new Exception("LastName is Required AmeNaneee ... ");

        if (phoneNumber.IsNotValidMobileNumber())
            throw new Exception("PhoneNumber is wrong");


        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        PhoneNumber = phoneNumber;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }
    public NationalCode NationalCode { get; private set; }

    public string PhoneNumber { get; private set; }

    public void Update(string firstName,
        string lastName,
        NationalCode nationalCode,
        string phoneNumber)
    {
        SetProperties(firstName, lastName, nationalCode, phoneNumber);
    }
}

public class NationalCode
{
    public NationalCode(string value)
    {
        if (!value.IsValidNationalCode())
            throw new Exception("National code is wrong....");

        Value=value;
        
    }
    public string Value { get;private set; }
}