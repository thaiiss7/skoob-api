using Skoob.Enums;

namespace Skoob.Models;

public class BookItem
{
    public Guid ID { get; set; }
    public float ?Rating { get; set; }
    public Label BookLabel { get; set; }
    public int PagesRead { get; set; } = 0;
    public bool Favorite { get; set; } = false;
    public Book Original { get; set; }
    public Guid OriginalBookId { get; set; }
    public Profile BookOwner { get; set; }
    public Guid OwnerId { get; set; }
    public Bookshelf Shelf { get; set; }
    public Guid ShelfId { get; set; }
    public TBR? YearTBR { get; set; }
    public Guid? TBRId { get; set; }
    public ICollection<ReadingLog> ReadingLogs { get; set; } = [];
}