using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Authentication.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence;

public class UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null) return null;
        return user.ToDomain();
    }

    public async Task<bool> IsValidPassword(User user, string password)
    {
        var userExisted = await userManager.FindByEmailAsync(user.Email);
        if (userExisted is null) return false;

        var result = await signInManager.PasswordSignInAsync(userExisted, password, false, false);
        if (result.Succeeded) return true;
        return false;
    }

    public async Task AddUser(User user, string password)
    {
        var appUser = new AppUser();
        appUser.UpdateFromDomain(user);

        await userManager.CreateAsync(appUser, password);
    }
}