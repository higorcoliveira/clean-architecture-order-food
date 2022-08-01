using ErrorOr;
using MediatR;
using OrderFood.Domain.Entities;
using OrderFood.Domain.Common.Errors;
using OrderFood.Application.Common.Interfaces.Authentication;
using OrderFood.Application.Common.Interfaces.Persistence;
using OrderFood.Application.Authentication.Common;

namespace OrderFood.Application.Authentication.Commands.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != command.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
