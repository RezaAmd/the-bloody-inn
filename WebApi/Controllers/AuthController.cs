using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Signup() => Ok();

    [HttpPost]
    public async Task<IActionResult> Signin() => Ok();
}