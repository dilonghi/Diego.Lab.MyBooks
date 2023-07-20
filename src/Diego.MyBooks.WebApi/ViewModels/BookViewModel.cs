using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.WebApi.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public Guid ReaderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty;
        public int Pages { get; set; }
        public EBookStatus Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid FormatBookIdId { get; set; }
        public bool Deleted { get; set; }

        public int CurrentPage { get; set; }
        public DateTime BookInReadingUpdateDate { get; set; }
    }
}
