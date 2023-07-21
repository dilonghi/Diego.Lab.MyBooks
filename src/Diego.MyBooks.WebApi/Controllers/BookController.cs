using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : MainController
{

    private readonly IBookRepository _bookRepository;

    public BookController(INotifier _notifier, IBookRepository bookRepository) : base(_notifier)
    {
        _bookRepository = bookRepository;
    }



    [HttpGet(Name = "{id}")]
    public async Task<IActionResult> Get()
    {
        var result = await _bookRepository.GetBookById(Guid.NewGuid());

        return CustomResponse(result);

        //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //    TemperatureC = Random.Shared.Next(-20, 55),
        //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //})
        //.ToArray();
    }
}
