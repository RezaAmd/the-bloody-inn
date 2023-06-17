namespace TheBloodyInn.WebApp.Areas.Account.Controllers;

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

    #endregion
}