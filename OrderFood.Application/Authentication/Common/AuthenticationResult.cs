using OrderFood.Domain.Entities;

namespace OrderFood.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);
