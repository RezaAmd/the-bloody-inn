namespace TheBloodyInn.WebApp.Areas.Account.Controllers;


[Area("Account")]
public class ProfileController : Controller
{
    #region Properties

    #endregion

    #region Ctor

    public ProfileController()
    {

    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    #endregion
}