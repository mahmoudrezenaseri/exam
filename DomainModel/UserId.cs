using Ackee.Domain.Model;

namespace DomainModel;

public class UserId : Id<Guid>
{
    protected UserId()
    {
    }

    public UserId(Guid id)
    {
        DbId = id;
    }


    public static UserId CreateNew()
    {
        return new UserId(Guid.NewGuid());
    }
    public static UserId CreateNew(Guid id)
    {
        return new UserId(id);
    }
}