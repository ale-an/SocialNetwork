using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Stubs;

public class StubFriendRepository : IFriendRepository
{
    private readonly List<FriendEntity> friends = new();

    public int Create(FriendEntity friendEntity)
    {
        friendEntity.id = friends.Count;
        friends.Add(friendEntity);
        return friendEntity.id;
    }

    public IEnumerable<FriendEntity> FindAllByUserId(int userId)
    {
        return friends.Where(x => x.user_id == userId).ToArray();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }
}