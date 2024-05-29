using Application.Services;
using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.User.Update;

public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountService _accountService;
    
    public UpdateUserCommandValidator(IUserRepository userRepository, IAccountService accountService)
    {
        _userRepository = userRepository;
        _accountService = accountService;

        RuleFor(user => user.ConfirmationPassword)
            .NotEmpty()
            .WithMessage("Please enter password for confirmation")
            .Must((model, password) => 
                _accountService.IsValidCredentials(model.Id, password))
            .WithMessage("Password isn't correct");
        
        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, _) =>
            {
                return !await _userRepository.IsEmailExistAsync(email);
            }).WithMessage("The email must be unique");
        RuleFor(user => user.Username)
            .NotEmpty()
            .MustAsync(async (username, _) =>
            {
                return !await _userRepository.IsUsernameExistAsync(username);
            }).WithMessage("The username must be unique");
    }
}