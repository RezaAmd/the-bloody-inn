using TheBloodyInn.Application.Common.Enums.User;
using TheBloodyInn.Application.Services.Identity;
using TheBloodyInn.Domain.Entities.Identities;
using TheBloodyInn.Domain.ValueObjects;

namespace TheBloodyInn.Application.Common.Commands.Users.Authentication.Signup;

public class SignUpUserCommand : IRequest<SignupStatus>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Nickname { get; set; }
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
        UserEntity newUser = new(request.Username);

        // Set password for user.
        newUser.SetPassword(PasswordHash.Parse(request.Password));

        // Set nickname.
        if (string.IsNullOrEmpty(request.Nickname) == false)
        {
            newUser.SetNickname(request.Nickname);
        }

        return await _identityService.SignUpAsync(newUser, cancellationToken);
    }
}

public sealed class SignUpUserCommandValidator : BaseFluentValidator<SignUpUserCommand>
{
    public SignUpUserCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            ;

        RuleFor(u => u.Password)
            .MinimumLength(4)
            .MaximumLength(50)
            ;
    }
}