using Exam.Core.Domain.Users.Entities;
using System.Threading.Tasks;

namespace Exam.Core.Domain.Users.Contracts
{
    public interface IUserCommandRepository
    {
        Task<User> UserGetById(int Id);
        Task<int> UserAdd(User user);
        Task<User> UserUpdate(User user);
    }
}
