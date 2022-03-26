using Exam.API.Model.Dto;
using Exam.API.Model.Entity;
using System.Linq;

namespace Exam.API.Model.Services
{
    public class UpdateUsersService : IUpdateUsersService
    {
        private DatabaseContext _db;
        public UpdateUsersService(DatabaseContext db)
        {
            this._db = db;
        }

        public void UpdateUser(int _NatinalCod,DtoUser dtoUsers)
        {
            Users users = _db.Users.FirstOrDefault(p => p.NationalCode == _NatinalCod);
            users.LastName = dtoUsers.LastName;
            users.FirstName = dtoUsers.FirstName;
            users.PhoneNumber = dtoUsers.PhoneNumber;

            _db.Update(_NatinalCod);    
            _db.SaveChangesAsync();
        }
    }
}
