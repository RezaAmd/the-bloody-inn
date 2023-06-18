using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace TheBloodyInn.WebApp.Controllers;

public class HomeController : Controller
{
    #region Properties

    private readonly ILogger<HomeController> _logger;

    #endregion

    #region Ctor

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    #endregion
}