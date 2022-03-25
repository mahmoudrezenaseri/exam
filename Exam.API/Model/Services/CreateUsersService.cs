
using Exam.API.Model.Entity;

namespace Exam.API.Model.Services
{
    public class CreateUsersService : ICreatUsersService
    {
        DatabaseContext _db;
        public CreateUsersService(DatabaseContext db)
        {
            this._db = db;
        }

        void ICreatUsersService.CreatUsers(User user)
        {
            _db.Users.Add(user);
            
        }
    }
}
