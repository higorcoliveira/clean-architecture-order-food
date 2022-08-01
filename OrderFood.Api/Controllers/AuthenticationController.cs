
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Contracts.Authentication;
using OrderFood.Application.Authentication.Commands.Register;
using OrderFood.Application.Authentication.Commands.Login;
using OrderFood.Application.Authentication.Common;

namespace OrderFood.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            autResult => Ok(MapResponse(autResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest login)
    {
        var query = new LoginQuery(login.Email, login.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

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
