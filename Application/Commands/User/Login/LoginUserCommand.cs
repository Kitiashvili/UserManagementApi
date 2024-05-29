using MediatR;

namespace Application.Commands.User.Login;

public sealed class LoginUserCommand : IRequest<string>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}