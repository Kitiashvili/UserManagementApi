using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.Roles.AddUserToRoles;

public sealed class AddUserToRoleCommandValidator : AbstractValidator<AddUserToRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    
    public AddUserToRoleCommandValidator(IRoleRepository roleRepository, 
        IUserRepository userRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        
        RuleFor(ur => ur.Role)
            .NotEmpty()
            .MustAsync(async (name, _) =>
            {
                return !await _roleRepository.IsRoleExistAsync(name);
            }).WithMessage("This role doesn't exist");
        
        RuleFor(ur => ur.Email)
            .NotEmpty()
            .MustAsync(async (email, _) =>
            {
                return await _userRepository.IsEmailExistAsync(email);
            }).WithMessage("This User doesn't exist");
        
    }
}