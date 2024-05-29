using Application.Commands.User.Register;
using Application.Services;
using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.User.Login;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountService _accountService;
    
    public LoginUserCommandValidator(
        IUserRepository userRepository,
        IAccountService accountService)
    {
        _userRepository = userRepository;
        _accountService = accountService;
        
        RuleFor(user => user.Password)
            .NotEmpty()
            .MaximumLength(20)
            .MinimumLength(6)
            .Matches("^(?=.*\\d).*$");

        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, _) =>
            {
                return await _userRepository.IsEmailExistAsync(email);
            }).WithMessage("User doesn't found");
        
        RuleFor(x => x.Password)
            .Must((model, password) => 
                _accountService.IsValidCredentials(model.Email, password))
            .WithMessage("Email or password isn't correct");

    }
}