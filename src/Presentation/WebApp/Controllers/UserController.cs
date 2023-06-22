using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.Signup;
using TheBloodyInn.Application.Common.Enums.User;
using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.WebApp.Models.User;

namespace TheBloodyInn.WebApp.Controllers;

public class UserController : Controller
{
    #region Properties

    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion

    #region Ctor

    public UserController(IMediator mediator,
        IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion

    #region SignIn

    [HttpGet]
    public IActionResult SignIn() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn([FromForm] SignInDto signinInput, CancellationToken cancellationToken)
    {
        var signinValidateCommandResult = await _mediator.Send(new SignInUserValidateCommand()
        {
            Username = signinInput.Username,
            Password = signinInput.Password
        }, cancellationToken);

        if (SignInStatus.Succeeded == signinValidateCommandResult.status)
        {
            #region Signin Cookie

            User user = signinValidateCommandResult.user;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };
            #region Roles
            //foreach (var userRole in user.UserRoles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            //}
            #endregion

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow
            };

#if DEBUG
            authProperties.ExpiresUtc.Value.AddDays(4);
#endif

            cancellationToken.ThrowIfCancellationRequested();
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                authProperties);

            #endregion

            return Redirect("/");
        }

        if (SignInStatus.Banned == signinValidateCommandResult.status)
            ModelState.AddModelError("IsBanned", "Your account has been ban from the admin!");

        if (SignInStatus.NotFound == signinValidateCommandResult.status)
            ModelState.AddModelError("NotFound", "The Username is wrong!");

        return View(signinInput);
    }

    #endregion

    #region SignUp

    [HttpGet]
    public IActionResult SignUp() => View();

    [HttpPost]
    public async Task<IActionResult> Signup([FromForm] SignUpUserCommand command, CancellationToken stoppingToken)
    {
        var signupUserCommandResult = await _mediator.Send(command, stoppingToken);

        // Already Exist
        if (signupUserCommandResult == SignupStatus.AlreadyExist)
            ModelState.AddModelError("AlreadyExist", "This username already exist!");
        // Failed
        if (signupUserCommandResult == SignupStatus.Succeded)
            ModelState.AddModelError("Failed", "Failed on signup. please try again later.");

        if (signupUserCommandResult == SignupStatus.Succeded)
            return RedirectToAction("SuccessfulRegistration");

        return View(command);
    }

    [HttpGet]
    public IActionResult SuccessfulRegistration()
    {
        return View();
    }

    #endregion

    #region SignOut

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Signout()
    {
        if (_httpContextAccessor.HttpContext is not null)
            await _httpContextAccessor.HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Redirect("/");
    }

    #endregion
}