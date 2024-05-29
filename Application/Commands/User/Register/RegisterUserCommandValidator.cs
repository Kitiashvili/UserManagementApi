using Domain.Repositories;
using FluentValidation;

namespace Application.Commands.User.Register;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, _) =>
            {
                return !await userRepository.IsEmailExistAsync(email);
            }).WithMessage("The email must be unique");

        RuleFor(user => user.Password)
            .NotEmpty()
            .MaximumLength(20)
            .MinimumLength(6)
            .Matches("^(?=.*\\d).*$");
        
        RuleFor(user => user.Username)
            .NotEmpty()
            .MustAsync(async (username, _) =>
            {
                return !await userRepository.IsUsernameExistAsync(username);
            }).WithMessage("The username must be unique");
    }
}