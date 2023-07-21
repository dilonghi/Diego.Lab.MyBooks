using Diego.MyBooks.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

public class MainController : ControllerBase
{
    private readonly INotifier _notifier;

    public MainController(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected bool ValidOperation()
    {
        return !_notifier.HaveNotification();
    }

    protected IActionResult CustomResponse(object result = null)
    {
        if (ValidOperation())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        var erro = _notifier.GetNotifications().Select(n => n.Message);

        return BadRequest(new
        {
            success = false,
            errors = erro
        });
    }
}
