using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.WebApi.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(Guid id, Guid readerId, string name, string resume, int pages, 
            EBookStatus status, DateTime insertDate, DateTime updateDate, EFormatBook formatBook)
        {
            Id = id;
            ReaderId = readerId;
            Name = name;
            Resume = resume;
            Pages = pages;
            Status = status;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            FormatBook = formatBook;
        }

        public Guid Id { get; set; }
        public Guid ReaderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty;
        public int Pages { get; set; }
        public EBookStatus Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public EFormatBook FormatBook { get; set; }
        public bool Deleted { get; set; }

        public int CurrentPage { get; set; }
        public DateTime BookInReadingUpdateDate { get; set; }


        public static implicit operator BookViewModel(Book book)
          => new(book.Id, book.ReaderId, book.Name, book.Resume, book.Pages, book.Status, book.InsertDate, book.UpdateDate, book.GetFormatBookEnumFromId(book.FormatBookId));


        public IEnumerable<BookViewModel> Books(IEnumerable<Book> books)
        {
            return (List<BookViewModel>)books;
        }


        public static implicit operator Book(BookViewModel bookViewModel)
              => new(bookViewModel.ReaderId, bookViewModel.Name, bookViewModel.Resume, bookViewModel.Pages, bookViewModel.FormatBook);
    }
}
