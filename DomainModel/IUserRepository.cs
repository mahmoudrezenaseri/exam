using Ackee.Domain.Model.Repositories;

namespace DomainModel;

public interface IUserRepository : IRepository<User, UserId>
{
}