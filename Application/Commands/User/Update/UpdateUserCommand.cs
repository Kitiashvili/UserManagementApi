using MediatR;

namespace Application.Commands.User.Update;

public sealed class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string ConfirmationPassword { get; set; } = string.Empty;
    public string? Email { get; set; } 
    public string? Username { get; set; }
}