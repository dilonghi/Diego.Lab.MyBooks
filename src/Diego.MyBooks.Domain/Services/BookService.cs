using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;
using System.Reflection.PortableExecutable;

namespace Diego.MyBooks.Domain.Services;

public class BookService : BaseService, IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(INotifier notificador, IBookRepository bookRepository) : base(notificador)
    {
        _bookRepository = bookRepository;
    }


    public async Task<Book> Insert(Book book)
    {
        if (!book.IsValid())
        {
            Notify(book.ValidationResult);
            return book;
        }
        var duplicateBook = await _bookRepository.GetBookByNomeAnReaderId(book.Name, book.ReaderId);

        if (duplicateBook is not null)
        {
            Notify($"This Reader allready have a Book with name {book.Name}");
            return book;
        }

        await _bookRepository.Insert(book);

        return book;
    }

    public async Task<Book> UpdateInfo(Guid id, Book updateBook)
    {
        if (!updateBook.IsValid())
        {
            Notify(updateBook.ValidationResult);
            return updateBook;
        }

        var book = await _bookRepository.GetBookById(id);

        if (book is null)
        {
            Notify("Reader not found");
            return updateBook;
        }

        var duplicateBook = await _bookRepository.GetBookByNomeAnReaderId(updateBook.Name, updateBook.ReaderId, id);

        if (duplicateBook is not null)
        {
            Notify("Allready exist a Reader with this Name and Email");
            return duplicateBook;
        }

        book.Update(id, updateBook.Name, updateBook.Resume, updateBook.Pages, updateBook.FormatBookId);

        await _bookRepository.Update(book);

        return book;
    }

    public async Task UpdateStatus(Guid bookId, EBookStatus status)
    {
        var book = await _bookRepository.GetBookById(bookId);

        if (book is null)
        {
            Notify("Book not exist");
            return;
        }

        await _bookRepository.Update(book.ChangeStatus(status));
    }


    public async Task Delete(Guid id)
    {
        var book = await _bookRepository.GetBookById(id);

        if (book is null)
        {
            Notify("Book not found");
            return;
        }

        await _bookRepository.Update(book.SetDeletd());
    }

}
