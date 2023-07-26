using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

[ApiController]
[Route("healthcheck")]
public class HealthcheckController : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> Index()
       => Ok($"[{DateTime.Now}] I am i live... ");

    
}
