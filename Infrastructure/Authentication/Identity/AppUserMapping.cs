using Domain.Entities;

namespace Infrastructure.Authentication.Identity;

public static class UserMapper
{
    public static User ToDomain(this AppUser entity)
    {
        return new User
        {
            Id          = entity.Id,
            FullName    = entity.UserName    ?? "",
            Email       = entity.Email       ?? "",
            PhoneNumber = entity.PhoneNumber ?? "",
            IsActive    = entity.IsActive
        };
    }

    public static void UpdateFromDomain(this AppUser entity, User user)
    {
        entity.IsActive    = user.IsActive;
        entity.UserName    = user.FullName;
        entity.Email       = user.Email;
        entity.PhoneNumber = user.PhoneNumber;
    }
}