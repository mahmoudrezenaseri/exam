
using Exam.API.Model.Dto;
using Exam.API.Model.Entity;
using System.Linq;

namespace Exam.API.Model.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext _databaseContext;
        public UserService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }



        public void CreatUser(UserDto userDto)
        {
            UserEntity user = new UserEntity()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                NationalCode = userDto.NationalCode,
                PhoneNumber = userDto.PhoneNumber,
            };
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }
        public UserDto GetUser(int id)
        {
            UserEntity user = _databaseContext.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {

                UserDto dtoUser = new UserDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NationalCode = user.NationalCode,
                    PhoneNumber = user.PhoneNumber,
                };
                return dtoUser;

            }
            else
            {
                UserDto dtoUser = new UserDto()
                {
                    FirstName = "Not Find",
                    LastName = "Not Find",
                    NationalCode = 0,
                    PhoneNumber = 0,
                };
                return dtoUser;
            }
            

        }
        public bool UpdateUser(int id, UserDto userDto)
        {
            UserEntity user = _databaseContext.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                user.LastName = userDto.LastName;
                user.FirstName = userDto.FirstName;
                user.PhoneNumber = userDto.PhoneNumber;
                user.NationalCode = userDto.NationalCode;

                _databaseContext.Update(user);
                _databaseContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }


    }
}
