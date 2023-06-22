namespace TheBloodyInn.WebApp.Areas.Admin.Controllers;

public class HomeController : Controller
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