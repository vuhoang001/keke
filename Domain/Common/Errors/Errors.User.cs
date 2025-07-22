using ErrorOr;

namespace Domain.Common.Errors;

public static class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(code: "User.DuplicateEmail", description: "Tài khoản đã tồn tại!");

        public static Error InvalidUsernameOrPassword => Error.Validation(code: "User.InvalidUsernameOrPassword",
            description: "Tài khoản hoặc mật khẩu không hợp lệ!");
    }
}