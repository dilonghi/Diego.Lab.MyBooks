using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Diego.MyBooks.Infra.Data.Repositories;

public class BookRepository : IBookRepository
{
    protected readonly MyBooksDbContext Db;

    public BookRepository(MyBooksDbContext db)
    {
        Db = db;
    }

    public async Task<IEnumerable<Book>> GetBooksByReader(Guid readerId)
    {
        return await Db.Book
            .AsNoTracking()
            .Where(x => x.ReaderId == readerId)
            .ToListAsync();
    }


    public async Task<Book> GetBookById(Guid id)
    {
        return await Db.Book
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Book> GetBookByNomeAnReaderId(string name, Guid readerId, Guid? id = null)
    {
        if (id == null)
            return await Db.Book
               .AsNoTracking()
               .Where(x => x.Name == name && x.ReaderId == readerId)
               .FirstOrDefaultAsync();

        return await Db.Book
               .AsNoTracking()
               .Where(x => x.Id != id && x.Name == name && x.ReaderId == readerId)
               .FirstOrDefaultAsync();
    }

    public async Task Insert(Book book)
    {
        Db.Book.Add(book);
        await SaveChangesAsync();

        Db.Entry(book).State = EntityState.Detached;
    }

    public async Task Update(Book book)
    {
        Db.Book.Update(book);
        await SaveChangesAsync();

        Db.Entry(book).State = EntityState.Detached;
    }

    
    public async Task<int> SaveChangesAsync()
    {
        return await Db.SaveChangesAsync();
    }
}
