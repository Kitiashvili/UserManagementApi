using Application.DTOs;
using MediatR;

namespace Application.Commands.Roles.CreateRole;

public sealed class CreateRoleCommand : IRequest<RoleDto>
{
    public string Name { get; set; } = string.Empty;
}