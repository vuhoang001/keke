namespace Application.Common.Interfaces.Authentication;

public interface IUserContextService
{
    public Guid? Sub { get; set; }

    public string Email { get; set; }
}