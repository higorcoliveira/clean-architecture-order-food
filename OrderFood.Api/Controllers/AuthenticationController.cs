
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Contracts.Authentication;
using OrderFood.Application.Services.Authentication;

namespace OrderFood.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return authResult.Match(
            autResult => Ok(MapResponse(autResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest login)
    {
        ErrorOr<AuthenticationResult> authResult = _authService.Login(login.Email, login.Password);

        return authResult.Match(
           autResult => Ok(MapResponse(autResult)),
           errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
    }
}
