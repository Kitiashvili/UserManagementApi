using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.Roles.CreateRole;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    
    public CreateRoleCommandValidator(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
        
        RuleFor(role => role.Name)
            .NotEmpty()
            .MustAsync(async (name, _) =>
            {
                return await _roleRepository.IsRoleExistAsync(name);
            }).WithMessage("The role already exist");
    }
}