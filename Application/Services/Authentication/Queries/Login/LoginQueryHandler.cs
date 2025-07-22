using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Services.Authentication.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Queries.Login;

public class LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(command.Email);

        if (user is null)
            return Errors.User.InvalidUsernameOrPassword;

        var checkLogin = await userRepository.IsValidPassword(user, command.Password);
        if (!checkLogin) return Errors.User.InvalidUsernameOrPassword;

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}