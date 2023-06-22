using TheBloodyInn.Application.Services.Identity;

namespace TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;

public class SignInUserCommand : IRequest<object>
{
    public string? Username { get; set; } // phonenumber
    public string? Password { get; set; }

}

public sealed class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, object>
{
    #region DI & Ctor
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;

    public SignInUserCommandHandler(IMediator mediator, IIdentityService identityService)
    {
        _identityService = identityService;
        _mediator = mediator;
    }
    #endregion

    public async Task<object> Handle(SignInUserCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var signInUserResult = await _identityService.SignInUserAsync(request.Username, request.Password, cancellationToken);

            if (!signInUserResult.HasValue)
                return ResultExtention.Failed("Server side error has occured.");

            if (signInUserResult.Value.Token is null)
                return ResultExtention.Failed(signInUserResult.Value.Status.ToString());

            return signInUserResult.Value.Token;
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }
    }
}