using Skoob.Enums;

namespace Skoob.Models;

public class BookItem
{
    public Guid ID { get; set; }
    public float ?Rating { get; set; }
    public Label BookLabel { get; set; }
    public Book Original { get; set; }
    public int PagesRead { get; set; }
    public Profile BookOwner { get; set; }
    public Bookshelf Shelf { get; set; }
}