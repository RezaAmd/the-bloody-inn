using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TheBloodyInn.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InnController : ControllerBase
{
    #region Ctor
    private readonly IMediator _mediator;

    public InnController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> Create() => Ok();

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok();

    [HttpDelete]
    public async Task<IActionResult> Delete(string id) => Ok();
}