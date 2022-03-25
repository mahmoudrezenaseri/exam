using Exam.API.Model.Entity;
using System.Linq;

namespace Exam.API.Model.Services
{
    public class GetUserServices : IGetUserServices 
    {
        DatabaseContext _db;
        public GetUserServices(DatabaseContext db)
        {
            this._db = db;
        }
        public User getuser(int _natiobalcod)
        {
            return  _db.Users.Where(u => u.NationalCode==_natiobalcod).FirstOrDefault();
            
            
        }
    }
}
