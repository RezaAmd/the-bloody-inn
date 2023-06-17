using Microsoft.AspNetCore.Mvc;

namespace TheBloodyInn.WebApp.Controllers;

public class CustomerController : Controller
{
    #region Ctor

    public CustomerController()
    {
        
    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Signin()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    #endregion
}
