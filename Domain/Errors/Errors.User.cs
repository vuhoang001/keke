using ErrorOr;

namespace Domain.Errors;

public static class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(code: "User.DuplicateEmail", description: "Email already exists");

        public static Error InvalidUsernameOrPassword => Error.Validation(code: "User.InvalidUsernameOrPassword",
            description: "Username or password is invalid");
    }
}