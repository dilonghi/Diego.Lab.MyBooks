using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diego.MyBooks.Domain.Models;

public class BookInReading
{
    public BookInReading(Guid id, Guid bookId, int currentPage)
    {
        Id = id;
        BookId = bookId;
        CurrentPage = currentPage;
        UpdateDate = DateTime.Now;
    }

    public BookInReading(Guid bookId, int currentPage)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        CurrentPage = currentPage;
        UpdateDate = DateTime.Now;
    }

    protected BookInReading()
    {
        
    }

    public Guid Id { get; private set; }
    public Guid BookId { get; private set; }
    public int CurrentPage { get; private set; }
    public DateTime UpdateDate { get; private set; }

    public virtual Book Book { get; set; }

}
