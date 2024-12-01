using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.Signup;
using TheBloodyInn.Application.Common.Enums.User;

namespace TheBloodyInn.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    #region Ctor
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpUserCommand signUpInputModel,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(signUpInputModel, cancellationToken);
        if (result != SignupStatus.Succeded)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] SignInUserCommand userLoginInformation,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(userLoginInformation, cancellationToken);
        return Ok(result);
    }
}