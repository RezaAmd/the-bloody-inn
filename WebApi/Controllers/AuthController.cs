using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Signup() => Ok();

    [HttpPost]
    public async Task<IActionResult> Signin() => Ok();
}