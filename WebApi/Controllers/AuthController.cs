using Microsoft.AspNetCore.Mvc;

namespace TheBloodyInn.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Signup() => Ok();

    [HttpPost]
    public async Task<IActionResult> Signin() => Ok();
}