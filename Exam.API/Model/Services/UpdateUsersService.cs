using Exam.API.Model.Entity;

namespace Exam.API.Model.Services
{
    public class UpdateUsersService : IUpdateUsersService
    {
        DatabaseContext _db;
        public UpdateUsersService(DatabaseContext db)
        {
            this._db = db;
        }

        public void UpdateUser(int _NatinalCod)
        {
            _db.Update(_NatinalCod);           
        }
    }
}
