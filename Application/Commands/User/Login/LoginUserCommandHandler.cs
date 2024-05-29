using Application.Authentication;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.User.Login;

internal sealed class LoginUserCommandHandler :  IRequestHandler<LoginUserCommand, string>
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserCommandHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        string token = await _jwtGenerator.GenerateTokenAsync(user);
        return token;
    }
}