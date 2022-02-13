using System.ComponentModel.DataAnnotations;

namespace Exam.API.Controllers;

public class CreateUserModel
{
    public string FirstName { get; set; }
    [Required] public string LastName { get; set; }

    [Required]
    //todo: nationalcode format
    public string NationalCode { get; set; }

    [Required]
    //phoneNumber format
    public string PhoneNumber { get; set; }
}