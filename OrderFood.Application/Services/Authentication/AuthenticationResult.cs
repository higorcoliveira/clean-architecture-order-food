using OrderFood.Domain.Entities;

namespace OrderFood.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
