namespace Skoob.Models;

public class Bookshelf
{
    public Guid ID { get; set; }
    public Profile Owner { get; set; }
    public Guid OwnerId { get; set; }
    public ICollection<BookItem>? BookItems { get; set; } = [];
    public ICollection<TBR> TBRs { get; set; } = [];
}