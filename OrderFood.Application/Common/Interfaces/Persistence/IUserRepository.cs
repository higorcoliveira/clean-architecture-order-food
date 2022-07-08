using OrderFood.Domain.Entities;

namespace OrderFood.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
