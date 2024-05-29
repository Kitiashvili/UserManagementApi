using Application.DTOs;
using MediatR;

namespace Application.Commands.User.Register;

public sealed class RegisterUserCommand : IRequest<UserDto>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}