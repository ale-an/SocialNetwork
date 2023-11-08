using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Stubs;

public class StubUserRepository : IUserRepository
{
    private readonly List<UserEntity> users = new();

    public int Create(UserEntity userEntity)
    {
        userEntity.id = users.Count;
        users.Add(userEntity);

        return userEntity.id;
    }

    public UserEntity FindByEmail(string email)
    {
        return users.FirstOrDefault(x => x.email == email);
    }

    public IEnumerable<UserEntity> FindAll()
    {
        return users;
    }

    public UserEntity FindById(int id)
    {
        return users.SingleOrDefault(x => x.id == id);
    }

    public int Update(UserEntity userEntity)
    {
        throw new NotImplementedException();
    }

    public int DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}