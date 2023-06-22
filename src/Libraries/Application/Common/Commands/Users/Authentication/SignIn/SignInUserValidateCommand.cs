using TheBloodyInn.Application.Common.Enums.User;
using TheBloodyInn.Application.Common.Models;
using TheBloodyInn.Application.Services.Identity;
using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;

public class SignInUserValidateCommand : IRequest<(User? user, SignInStatus status)>
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public sealed class SignInUserValidateCommandHandler : IRequestHandler<SignInUserValidateCommand, (User? user, SignInStatus status)>
{
    #region DI & Ctor
    private readonly IIdentityService _identityService;

    public SignInUserValidateCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    #endregion

    public async Task<(User? user, SignInStatus status)> Handle(SignInUserValidateCommand request, CancellationToken cancellationToken = default)
    => await _identityService.SignInValidateAsync(request.Username, request.Password, cancellationToken);
}

public sealed class SignInUserValidateCommandValidator : BaseFluentValidator<SignInUserValidateCommand>
{
    public SignInUserValidateCommandValidator()
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