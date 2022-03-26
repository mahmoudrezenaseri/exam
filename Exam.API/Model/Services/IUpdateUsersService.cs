using Exam.API.Model.Dto;

namespace Exam.API.Model.Services
{
    public interface IUpdateUsersService
    {
        public void UpdateUser(int _NatinalCod,DtoUser dtoUsers);
    }
}
