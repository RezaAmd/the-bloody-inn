using TheBloodyInn.Application.Services.Cards;

namespace TheBloodyInn.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
public class CardController : Controller
{

    #region Fields

    private readonly ICardService _cardService;

    #endregion

    #region Ctor

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult List()
    {
        var cards = _cardService.GetAllGuestPatterns()
            .OrderBy(c => Guid.NewGuid())
            .ToList();
        return View(cards);
    }

    #endregion
}