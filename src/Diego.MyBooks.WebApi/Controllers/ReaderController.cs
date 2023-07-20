using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Diego.MyBooks.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReaderController : ControllerBase
{
    private readonly IReaderService _readerService;
    private readonly IReaderRepository _readerRepository;

    public ReaderController(IReaderRepository readerRepository, IReaderService readerService)
    {
        _readerRepository = readerRepository;
        _readerService = readerService;
    }


    [HttpGet(Name = "{id:guid}")]
    public async Task<IActionResult> GetReader(Guid id)
    {
        var readerViewModel = new ReaderViewModel();

        readerViewModel = await _readerRepository.GetReaderById(id);

        return Ok(new { success = true, data = readerViewModel });
    }

    [HttpPost(Name = "")]
    public async Task<IActionResult> Post(ReaderViewModel readerViewModel)
    {
        await _readerService.Insert(readerViewModel);

        // TO DO implement notification pattern

        return Ok(new { success = true, data = new ReaderViewModel() });
    }

    [HttpPut(Name = "{id:guid}")]
    public async Task<IActionResult> Put()
    {

        return Ok(new { success = true, data = new ReaderViewModel() });
    }

    [HttpDelete(Name = "{id:guid}")]
    public async Task<IActionResult> Delete()
    {

        return Ok(new { success = true, data = new ReaderViewModel() });
    }
}
