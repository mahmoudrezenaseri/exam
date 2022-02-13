using Ackee.DataAccess.EfCore;
using Ackee.Domain.Model.EventManager;
using DomainModel;

namespace Infrastructure
{
    public class UserRepository : EfCoreRepository<User,UserId>,IUserRepository
    {
        public UserRepository(AckeeDbContext dbContext, IEventPublisher eventPublisher) : base(dbContext, eventPublisher)
        {
        }

        public override Task<UserId> GetNextId()
        {
            throw new NotImplementedException();
        }
    }
}