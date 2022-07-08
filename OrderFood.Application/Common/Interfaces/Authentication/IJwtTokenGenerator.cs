using OrderFood.Domain.Entities;

namespace OrderFood.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
