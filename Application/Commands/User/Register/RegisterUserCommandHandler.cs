using Application.Authentication;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.User.Register;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IJwtGenerator _jwtGenerator;
    public RegisterUserCommandHandler(
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository,
        IPasswordHasher passwordHasher, 
        IMapper mapper, IJwtGenerator jwtGenerator)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasher.Hash(request.Password);

        var createdUser = UserEntity.Create( request.Username, request.Email, passwordHash);
        
        await _userRepository.CreateAsync(createdUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<UserDto>(createdUser);
    }
}