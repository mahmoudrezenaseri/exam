
using Exam.API.Model.Dto;
using Exam.API.Model.Entity;

namespace Exam.API.Model.Services
{
    public interface IUserService
    {

        void CreatUser(UserDto userDto);
        bool UpdateUser(int id,UserDto userDto);
        UserDto GetUser(int id);
    }
}
