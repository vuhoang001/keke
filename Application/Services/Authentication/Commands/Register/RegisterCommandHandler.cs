using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Services.Authentication.Common;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByEmail(command.Email) is not null)
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateEmail);

        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
        };

        userRepository.AddUser(user);

        var token = jwtTokenGenerator.GenerateToken(user);
        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(user, token));
    }
}