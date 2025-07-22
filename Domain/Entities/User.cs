namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Tên
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Họ
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Tên đầy đủ
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Trạng thái
    /// </summary>
    public bool IsActive { get; set; }
}