using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

public class FriendView
{
    FriendService friendService;

    public FriendView(FriendService friendService)
    {
        this.friendService = friendService;
    }

    public void Show(User user)
    {
        Console.WriteLine("Показать друзей (нажмите 1)");
        Console.WriteLine("Добавить пользователя в друзья (нажмите 2)");

        switch (Console.ReadLine())
        {
            case "1":
            {
                var friends = friendService.FriendList(user.Id);
                foreach (var person in friends)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }

                break;
            }

            case "2":
            {
                Console.WriteLine("Введите email пользователя, которого хотите добавить в друзья");
                var email = Console.ReadLine();
                friendService.AddFriend(user.Id, email);
                break;
            }
        }
    }
}