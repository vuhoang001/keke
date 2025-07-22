using Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Commands.Register;

public record RegisterCommand(string UserName, string Email, string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;