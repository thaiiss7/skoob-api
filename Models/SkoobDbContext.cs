using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Skoob.Models;

public class SkoobDbContext(DbContextOptions<SkoobDbContext> options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookItem> BookItems => Set<BookItem>();
    public DbSet<Bookshelf> Bookshelves => Set<Bookshelf>();
    public DbSet<ReadingLog> ReadingLogs => Set<ReadingLog>();
    public DbSet<TBR> TBRs => Set<TBR>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>();

        model.Entity<Book>();

        model.Entity<BookItem>()
        .HasOne(b => b.Original)
        .WithMany(o => o.Items)
        .HasForeignKey(o => o.ID)
        .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Bookshelf>()
        .HasOne(s => s.Owner)
        .WithOne(o => o.UserShelf)
        .OnDelete(DeleteBehavior.NoAction);
    }
}