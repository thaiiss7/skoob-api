namespace Skoob.Models;

public class TBR
{
    public Guid ID { get; set; }
    public int Year { get; set; }
    public Bookshelf Shelf { get; set; }
    public Guid ShelfId { get; set; }
    public ICollection<BookItem> Books { get; set; } = [];
}