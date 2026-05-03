namespace Skoob.Models;

public class Book
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public int NumberOfPages { get; set; }
    public string Author { get; set; }
    public string ?About { get; set; }
    public int Year { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<BookItem> Items { get; set; } = [];
}