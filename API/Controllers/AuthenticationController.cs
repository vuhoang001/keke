using Application.Services.Authentication;
using Application.Services.Authentication.Commands;
using Application.Services.Authentication.Commands.Register;
using Application.Services.Authentication.Common;
using Application.Services.Authentication.Queries;
using Application.Services.Authentication.Queries.Login;
using Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace keke.Controllers;

[Route("api/[controller]")]
public class AuthenticationController(
    ISender mediator,
    IMapper mapper
) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RequestRegister request)
    {
        var registerCommand = mapper.Map<RegisterCommand>(request);
        var authResult = await mediator.Send(registerCommand);

        return authResult.Match(
            response => Ok(mapper.Map<AuthenticationResponse>(response)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginQuery = mapper.Map<LoginQuery>(request);
        var authResult = await mediator.Send(loginQuery);

        return authResult.Match(
            response => Ok(mapper.Map<AuthenticationResponse>(response)),
            errors => Problem(errors));
    }
}