using Application.Common.Interfaces.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = [];


    public User? GetUserByEmail(string email)
    {
        var singleOrDefault = _users.FirstOrDefault(u => u.Email == email);
        return singleOrDefault;
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}