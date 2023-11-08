using System.ComponentModel.DataAnnotations;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.PLL.Services;

public class MessageService
{
    IMessageRepository messageRepository;
    IUserRepository userRepository;

    public MessageService()
    {
        messageRepository = new MessageRepository();
        userRepository = new UserRepository();
    }

    public void Send(int senderId, string email, string userMessage)
    {
        if (String.IsNullOrEmpty(userMessage)) throw new ArgumentNullException();

        if (userMessage.Length > 5000) throw new ArgumentOutOfRangeException();

        if (!new EmailAddressAttribute().IsValid(email)) throw new ArgumentNullException();

        var user = userRepository.FindByEmail(email);

        if (user == null) throw new UserNotFoundException();

        var messageEntity = new MessageEntity()
        {
            content = userMessage,
            sender_id = senderId,
            recipient_id = user.id
        };

        if (messageRepository.Create(messageEntity) == 0)
            throw new Exception();
    }
}