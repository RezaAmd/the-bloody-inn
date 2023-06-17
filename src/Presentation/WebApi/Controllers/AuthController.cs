using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;
using TheBloodyInn.Domain.ValueObjects;

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
    public async Task<IActionResult> Signup() => Ok(PasswordHash.Parse("123456"));

    [HttpPost]
    public async Task<IActionResult> Signin([FromBody] SignInUserCommand userLoginInformation, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(userLoginInformation, cancellationToken);
        return Ok(result);
    }
}