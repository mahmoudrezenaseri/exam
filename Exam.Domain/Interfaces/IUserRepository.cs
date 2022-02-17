using Exam.Domain.Entities;

namespace Exam.Domain.Interfaces;

public interface IUserRepository
{
    Task <List<User>> GetAllUsers();

    Task<User?> GetUserById(Guid id);

    Task<User?> CreateUser(User user);

    Task<User?> UpdateUser(User user);

    Task DeleteAllUsers();
}
