using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace keke.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RequestRegister request)
    {
        return Ok(authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(authenticationService.Login(request.Email, request.Password));
    }
}