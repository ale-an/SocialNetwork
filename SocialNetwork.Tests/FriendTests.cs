using NUnit.Framework;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.Stubs;

namespace SocialNetwork;

[TestFixture]
public class FriendTests
{
    [Test]
    public void AddFriendTest()
    {
        var stubUserRepository = new StubUserRepository();
        stubUserRepository.Create(new UserEntity
        {
            id = 0,
            firstname = "Иван",
            lastname = "Иванов",
            email = "iv@iv.ru"
        });
        var user2Id = stubUserRepository.Create(new UserEntity
        {
            id = 1,
            firstname = "Петя",
            lastname = "Петров",
        });

        var friendService = new FriendService(stubUserRepository, new StubFriendRepository());

        friendService.AddFriend(user2Id, "iv@iv.ru");

        var friends = friendService.FriendList(user2Id);

        Assert.That(friends.Length == 1);
        Assert.That(friends[0].FirstName == "Иван");
        Assert.That(friends[0].LastName == "Иванов");
    }
}