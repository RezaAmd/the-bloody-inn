namespace TheBloodyInn.WebApp.Areas.Account.Controllers;

[Area("Account")]
public class InnController : Controller
{
    #region Properties

    #endregion

    #region Ctor

    public InnController()
    {

    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Board()
    {
        return View();
    }
    #endregion
}