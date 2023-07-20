using Diego.MyBooks.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }




    [HttpGet(Name = "reader/books/{id}")]
    public async Task<IEnumerable<Books>> Get()
    {
        var result = await _bookRepository.GetBookById(Guid.NewGuid());

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
