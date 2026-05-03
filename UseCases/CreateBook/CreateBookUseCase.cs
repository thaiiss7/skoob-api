using Skoob.Models;

namespace Skoob.UseCases.CreateBook;

public class CreateBookUseCase(SkoobDbContext ctx)
{
    public async Task<Result<CreateBookResponse>> Do(CreateBookPayload payload)
    {
        var book = new Book
        {
            Title = payload.Title,
            NumberOfPages = payload.NumberOfPages,
            Author = payload.Author,
            About = payload.About,
            Year = payload.Year,
            ImageUrl = payload.ImageUrl
        };

        ctx.Books.Add(book);
        await ctx.SaveChangesAsync();
        
        return Result<CreateBookResponse>.Success(new());
    }
}