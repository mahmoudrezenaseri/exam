using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Models.Entities
{
    public class User
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }


      
        public static User Create(string firstName, string lastName, string phoneNumber, string nationalCode)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                NationalCode = nationalCode,
            };
        }

        public void Edit(string firstName, string lastName, string phoneNumber, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }


    }
}
