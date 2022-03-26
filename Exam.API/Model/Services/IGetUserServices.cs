using Exam.API.Model.Dto;
using Exam.API.Model.Entity;

namespace Exam.API.Model.Services
{
    public interface IGetUserServices
    {
        DtoUser getuser(int _NatinalCod);
    }
}
