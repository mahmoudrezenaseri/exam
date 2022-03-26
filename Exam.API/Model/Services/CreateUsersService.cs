
using Exam.API.Model.Dto;
using Exam.API.Model.Entity;

namespace Exam.API.Model.Services
{
    public class CreateUsersService : ICreatUsersService
    {
        private DatabaseContext _db;
        public CreateUsersService(DatabaseContext db)
        {
            this._db = db;
        }

  

        public void  CreatUsers(DtoUser dtouser)
        {
            Users users = new Users()
            {
                FirstName = dtouser.FirstName,
                LastName = dtouser.LastName,    
                NationalCode = dtouser.NationalCode,
                PhoneNumber = dtouser.PhoneNumber,
            };
            _db.Users.Add(users);
        }
    }
}
