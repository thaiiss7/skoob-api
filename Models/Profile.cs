namespace Skoob.Models;

public class Profile
{
    public Guid ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ?Bio { get; set; }
    public Bookshelf UserShelf { get; set; }
    public Guid ShelfId { get; set; }
    public ICollection<ReadingLog> ReadingLogs { get; set; } = [];
}