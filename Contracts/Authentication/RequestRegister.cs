namespace Contracts.Authentication;

public record RequestRegister(
    string FirstName,
    string LastName,
    string Email,
    string Password
);