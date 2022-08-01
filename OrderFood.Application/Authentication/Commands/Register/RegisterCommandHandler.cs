using ErrorOr;
using MediatR;
using OrderFood.Domain.Entities;
using OrderFood.Domain.Common.Errors;
using OrderFood.Application.Common.Interfaces.Authentication;
using OrderFood.Application.Common.Interfaces.Persistence;
using OrderFood.Application.Authentication.Common;

namespace OrderFood.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User { FirstName = command.FirstName, LastName = command.LastName, Email = command.Email, Password = command.Password };
        _userRepository.Add(user);
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
