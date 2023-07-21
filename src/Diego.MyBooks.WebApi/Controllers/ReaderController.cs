using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

[ApiController]
[Route("readers")]
public class ReaderController : MainController
{
    private readonly IReaderService _readerService;
    private readonly IReaderRepository _readerRepository;
    private readonly IBookRepository _bookRepository;

    public ReaderController(INotifier _notifier, IReaderRepository readerRepository, IReaderService readerService, IBookRepository bookRepository) : base(_notifier)
    {
        _readerRepository = readerRepository;
        _readerService = readerService;
        _bookRepository = bookRepository;
    }

    [HttpGet("{readerId:guid}/books")]
    public async Task<IActionResult> GetReaderBooks(Guid readerId)
    {
        var books = await _bookRepository.GetBooksByReader(readerId);

        if(!books.Any())
            return CustomResponse();

        var booksViewModel = new List<BookViewModel>();

        foreach (var book in books)
        {
            booksViewModel.Add(book);
        }

        return CustomResponse(booksViewModel);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetReader(Guid id)
        => CustomResponse((ReaderViewModel)await _readerRepository.GetReaderById(id));
    

    [HttpPost("")]
    public async Task<IActionResult> Post(ReaderViewModel readerViewModel)
    {
        if (!ModelState.IsValid) 
            return CustomResponse(readerViewModel);

        readerViewModel = await _readerService.Insert(readerViewModel);

        return CustomResponse(readerViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, ReaderViewModel readerViewModel)
    {
        if (!ModelState.IsValid)
            return CustomResponse(readerViewModel);

        readerViewModel = await _readerService.Update(id, readerViewModel);

        return CustomResponse(readerViewModel);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _readerService.Delete(id);

        return CustomResponse();
    }


}
