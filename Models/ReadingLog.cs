namespace Skoob.Models;

public class ReadingLog
{
    public Guid ID { get; set; }
    public int PagesRead { get; set; }
    public DateTime Time { get; set; }
    public Profile User { get; set; }
    public BookItem BookRead { get; set; }
}