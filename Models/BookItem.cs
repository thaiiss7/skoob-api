using Skoob.Enums;

namespace Skoob.Models;

public class BookItem
{
    public Guid ID { get; set; }
    public float ?Rating { get; set; }
    public Label BookLabel { get; set; }
    public int PagesRead { get; set; }
    public bool? Favorite { get; set; }
    public Book Original { get; set; }
    public Guid OriginalBookId { get; set; }
    public Profile BookOwner { get; set; }
    public Guid OwnerId { get; set; }
    public Bookshelf Shelf { get; set; }
    public Guid ShelfId { get; set; }
}