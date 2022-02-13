using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Models.DTOs
{
    public class EditUser
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"09(1[0-9]|3[1-9])[0-9]{7}", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(10)]
        public string NationalCode { get; set; }

        public EditUser(long id, string firstName, string lastName, string phoneNumber, string nationalCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
    }
}
