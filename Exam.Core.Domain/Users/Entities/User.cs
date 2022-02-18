using Exam.Framework.Domain.Entities;

namespace Exam.Core.Domain.Users.Entities
{
    public class User : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
