using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace Application.Services.Authentication.Queries.Login;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(request => request.Email).NotEmpty();
        RuleFor(request => request.Password).NotEmpty();
    }
}