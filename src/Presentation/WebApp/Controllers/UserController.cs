using TheBloodyInn.Application.Common.Commands.Users.Authentication.Signup;
using TheBloodyInn.Application.Common.Enums.IdentityService;

namespace TheBloodyInn.WebApp.Controllers;

public class UserController : Controller
{
    #region Properties

    private readonly IMediator _mediator;

    #endregion

    #region Ctor

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult SignUp() => View();

    [HttpPost]
    public async Task<IActionResult> Signup([FromForm] SignUpUserCommand command, CancellationToken stoppingToken)
    {
        var signupUserCommandResult = await _mediator.Send(command, stoppingToken);

        // Already Exist
        if (signupUserCommandResult == UserSignupStatus.AlreadyExist)
            ModelState.AddModelError("AlreadyExist", "This username already exist!");
        // Failed
        if (signupUserCommandResult == UserSignupStatus.Succeded)
            ModelState.AddModelError("Failed", "Failed on signup. please try again later.");

        if (signupUserCommandResult == UserSignupStatus.Succeded)
            return RedirectToAction("SuccessfulRegistration");

        return View(command);
    }

    [HttpGet]
    public IActionResult SuccessfulRegistration()
    {
        return View();
    }
    #endregion
}