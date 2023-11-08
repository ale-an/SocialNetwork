using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class FriendService
{
    private readonly IUserRepository userRepository;
    private readonly IFriendRepository friendRepository;

    public FriendService(IUserRepository userRepository, IFriendRepository friendRepository)
    {
        this.userRepository = userRepository;
        this.friendRepository = friendRepository;
    }

    public void AddFriend(int userId, string email)
    {
        var friend = userRepository.FindByEmail(email);
        if (friend is null) throw new UserNotFoundException();

        friendRepository.Create(new FriendEntity
        {
            user_id = userId,
            friend_id = friend.id
        });
    }

    public Friend[] FriendList(int userId)
    {
        var friends = friendRepository.FindAllByUserId(userId)
            .Select(x => x.friend_id).ToArray();

        var users = userRepository.FindAll()
            .Where(x => friends.Contains(x.id)).ToArray();

        return users.Select(x => new Friend(x.firstname, x.lastname)).ToArray();
    }
}