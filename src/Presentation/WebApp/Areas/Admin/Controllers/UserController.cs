namespace TheBloodyInn.WebApp.Areas.Admin.Controllers;


[Area("Admin")]
public class UserController : Controller
{
    #region Props



    #endregion

    #region Ctor



    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    #endregion
}
