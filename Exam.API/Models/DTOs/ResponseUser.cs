using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Models.DTOs
{
    public class ResponseUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }

        public ResponseUser(long id,string firstName, string lastName, string phoneNumber, string nationalCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }

    }
}
