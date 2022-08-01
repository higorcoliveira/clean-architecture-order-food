using ErrorOr;
using MediatR;
using OrderFood.Application.Authentication.Common;

namespace OrderFood.Application.Authentication.Commands.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
