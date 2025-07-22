using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Authentication.Identity;

public class AppUser : IdentityUser<Guid>
{
    /// <summary>
    /// Trạng thái
    /// </summary>
    public bool IsActive { get; set; } = false;

    /// <summary>
    /// Trạng thái danh sách đen
    /// </summary>
    public bool IsBacklisted { get; set; } = false;
}