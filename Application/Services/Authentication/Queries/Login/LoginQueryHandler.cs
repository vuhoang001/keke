using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Services.Authentication.Common;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Queries.Login;

public class LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByEmail(command.Email) is not { } user)
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.InvalidUsernameOrPassword);

        if (user.Password != command.Password)
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.InvalidUsernameOrPassword);

        var token = jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(user, token));
    }
}