using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);

    Task<bool> IsValidPassword(User user, string password);

    Task AddUser(User user, string password);
}