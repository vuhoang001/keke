namespace Contracts.Authentication;

public record RequestRegister(
    string UserName,
    string Email,
    string Password
);