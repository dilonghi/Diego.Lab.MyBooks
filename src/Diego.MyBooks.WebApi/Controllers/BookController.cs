using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models.ValueObjects;
using Diego.MyBooks.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

[ApiController]
[Route("books")]
public class BookController : MainController
{

    private readonly IBookRepository _bookRepository;
    private readonly IBookService _bookService;

    public BookController(INotifier _notifier, IBookRepository bookRepository, IBookService bookService) : base(_notifier)
    {
        _bookRepository = bookRepository;
        _bookService = bookService;
    }



    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBook(Guid id)
       => CustomResponse((BookViewModel)await _bookRepository.GetBookById(id));

    [HttpPost("")]
    public async Task<IActionResult> Post(BookViewModel bookViewModel)
    {
        if (!ModelState.IsValid)
            return CustomResponse(bookViewModel);

        bookViewModel = await _bookService.Insert(bookViewModel);

        return CustomResponse(bookViewModel);
    }

    [HttpPut("{id:guid}/infos")]
    public async Task<IActionResult> UpdateInfos(Guid id, BookViewModel bookViewModel)
    {
        if (!ModelState.IsValid)
            return CustomResponse(bookViewModel);

        bookViewModel = await _bookService.UpdateInfo(id, bookViewModel);

        return CustomResponse(bookViewModel);
    }

    [HttpPut("{id:guid}/status/{status}")]
    public async Task<IActionResult> UpdateStatus(Guid id, EBookStatus status)
    {
        await _bookService.UpdateStatus(id, status);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.Delete(id);

        return CustomResponse();
    }
}
