using Application.DTOs;
using MediatR;

namespace Application.Commands.Roles.AddUserToRoles;

public sealed class AddUserToRoleCommand : IRequest<UserRoleDto>
{
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}