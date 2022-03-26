using Exam.API.Model.Dto;
using Exam.API.Model.Entity;
using System.Linq;

namespace Exam.API.Model.Services
{
    public class GetUserServices : IGetUserServices 
    {
        private DatabaseContext _db;
        public GetUserServices(DatabaseContext db)
        {
            this._db = db;
        }
        public DtoUser getuser(int _NatinalCod)
        {
            Users users = _db.Users.FirstOrDefault(p => p.NationalCode == _NatinalCod);
            DtoUser dtoUser = new DtoUser()
            {
                FirstName = users.FirstName,
                LastName = users.LastName,  
                NationalCode = users.NationalCode,
                PhoneNumber = users.PhoneNumber,

            };
            return dtoUser;

        }
    }
}
