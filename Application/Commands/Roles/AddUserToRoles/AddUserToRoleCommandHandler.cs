using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.Roles.AddUserToRoles;

public sealed class AddUserToRoleCommandHandler : IRequestHandler<AddUserToRoleCommand, UserRoleDto>
{
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddUserToRoleCommandHandler(
        IUserRolesRepository userRolesRepository, 
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository, 
        IRoleRepository roleRepository, IMapper mapper)
    {
        _userRolesRepository = userRolesRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<UserRoleDto> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        var role = await _roleRepository.GetRoleByNameAsync(request.Role);
        
        var userRole = UserRoleEntity.Create( user.Id, role.Id);
        
        await _userRolesRepository.CreateAsync(userRole);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UserRoleDto>(userRole);
    }
}