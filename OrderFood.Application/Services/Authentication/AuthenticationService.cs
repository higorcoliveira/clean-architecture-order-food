
using OrderFood.Application.Common.Interfaces.Authentication;
using OrderFood.Application.Common.Interfaces.Persistence;
using OrderFood.Domain.Entities;

namespace OrderFood.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already registered.");
        }

        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };
        _userRepository.Add(user);
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User does not exist.");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid credentials.");
        }
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
