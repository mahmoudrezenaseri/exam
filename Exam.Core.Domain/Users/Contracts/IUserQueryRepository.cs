using Exam.Core.Domain.Users.Entities;
using System.Threading.Tasks;

namespace Exam.Core.Domain.Users.Contracts
{
    public interface IUserQueryRepository
    {
        Task<User> UserGetById(int Id);
    }
}
