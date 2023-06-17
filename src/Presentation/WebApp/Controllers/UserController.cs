namespace TheBloodyInn.WebApp.Controllers;

public class UserController : Controller
{
    #region Ctor

    public UserController()
    {

    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Authentication()
    {
        return View();
    }

    #endregion
}