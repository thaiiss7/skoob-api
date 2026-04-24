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

        // bookitem - book
        model.Entity<BookItem>()
        .HasOne(b => b.Original)
        .WithMany(o => o.Items)
        .HasForeignKey(b => b.OriginalBookId)
        .OnDelete(DeleteBehavior.NoAction);

        // bookshlef - user
        model.Entity<Bookshelf>()
        .HasOne(s => s.Owner)
        .WithOne(o => o.UserShelf)
        .OnDelete(DeleteBehavior.NoAction);

        // bookshelf - book item
        model.Entity<Bookshelf>()
        .HasMany(s => s.BookItems)
        .WithOne(i => i.Shelf)
        .HasForeignKey(i => i.ShelfId)
        .OnDelete(DeleteBehavior.NoAction);

        // reading log - user
        model.Entity<ReadingLog>()
        .HasOne(r => r.User)
        .WithMany(u => u.ReadingLogs)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        // reading log - bookitem
        model.Entity<ReadingLog>()
        .HasOne(r => r.BookRead)
        .WithMany(b => b.ReadingLogs)
        .HasForeignKey(r => r.BookId)
        .OnDelete(DeleteBehavior.NoAction);

        // tbr - bookitem
        model.Entity<TBR>()
        .HasMany(t => t.Books)
        .WithOne(b => b.YearTBR)
        .HasForeignKey(b => b.TBRId)
        .OnDelete(DeleteBehavior.NoAction);

        // tbr - bookshelf
        model.Entity<TBR>()
        .HasOne(t => t.Shelf)
        .WithMany(s => s.TBRs)
        .HasForeignKey(t => t.ShelfId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}