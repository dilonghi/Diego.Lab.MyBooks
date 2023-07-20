using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.Domain.Services;

public class BookService : BaseService, IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(INotifier notificador, IBookRepository bookRepository) : base(notificador)
    {
        _bookRepository = bookRepository;
    }

    
    public async Task Insert(Book book)
    {
        if (book.IsInvalid())
        {
            Notify(book.ValidationResult);
            return;
        }
        var duplicateBook = await _bookRepository.GetBookByNomeAnReaderId(book.Name, book.ReaderId);

        if (duplicateBook is not null)
        {
            Notify($"This Reader allready have a Book with name {book.Name}");
            return;
        }

        await _bookRepository.Insert(book);
    }

    public async Task UpdateInfo(Book book)
    {
        if (book.IsInvalid())
        {
            Notify(book.ValidationResult);
            return;
        }

        var duplicateReader = await _bookRepository.GetBookByNomeAnReaderId(book.Name, book.ReaderId, book.Id);

        if (duplicateReader is not null)
        {
            Notify($"This Reader allready have a Book with name {book.Name}");
            return;
        }

        await _bookRepository.Update(book);
    }

    public async Task UpdateStatus(Guid bookId, EBookStatus status)
    {
        var book = await _bookRepository.GetBookById(bookId);

        if (book is not null)
            await _bookRepository.Update(book.ChangeStatus(status));

        Notify("Book not exist");
    }


    public async Task Delete(Guid id)
    {
        var book = await _bookRepository.GetBookById(id);

        if (book is not null)
            await _bookRepository.Delete(book.SetDeletd());

        Notify("Book not exist");
    }

}
