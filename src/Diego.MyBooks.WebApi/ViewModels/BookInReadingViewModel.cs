namespace Diego.MyBooks.WebApi.ViewModels;

public class BookInReadingViewModel
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public int CurrentPage { get; set; }
    public DateTime UpdateDate { get; set; }
}
