using TheBloodyInn.Application.Common.Enums.IdentityService;
using TheBloodyInn.Application.Common.Models;
using TheBloodyInn.Application.Services.Identity;
using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Domain.ValueObjects;

namespace TheBloodyInn.Application.Common.Commands.Users.Authentication.Signup;

public class SignUpUserCommand : IRequest<SignupStatus>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public sealed class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, SignupStatus>
{
    private readonly IIdentityService _identityService;
    public SignUpUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<SignupStatus> Handle(SignUpUserCommand request, CancellationToken cancellationToken = default)
    {
        // Create new user object.
        User newUser = new(request.Email);
        newUser.SetNewEmail(request.Email);
        newUser.PasswordHash = PasswordHash.Parse(request.Password);

        return await _identityService.SignUpAsync(newUser, cancellationToken);
    }
}

public sealed class SignUpUserCommandValidator : BaseFluentValidator<SignUpUserCommand>
{
    public SignUpUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .MinimumLength(7)
            .MaximumLength(50)
            ;

        RuleFor(u => u.Password)
            .MinimumLength(4)
            .MaximumLength(50)
            ;
    }
}