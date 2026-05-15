using Microsoft.EntityFrameworkCore;
using Skoob.Models;

namespace Skoob.UseCases.GetBookData;
public class GetBookDataUseCase(SkoobDbContext ctx)
{
    public async Task<Result<GetBookDataResponse>> Do(GetBookDataPayload payload)
    {
        var book = await ctx.Books
        .Include(b => b.Items)
            .ThenInclude(i => i.Rating)
        .FirstOrDefaultAsync(b => b.Title == payload.Title);

        var user = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.UserId);
        
        bool hasbook = false;

        if (book is null)
            return Result<GetBookDataResponse>.Failure("Book not found");

        var items = book.Items;

        float rating = items
            .Where(i => i.Rating != null)
            .Average(i => i.Rating.Value);

        int numberOfFavorites = items.Count(i => i.Favorite);
        int numberOfRead = items.Count(i => i.BookLabel == Enums.Label.Read);
        int numberOfReading = items.Count(i => i.BookLabel == Enums.Label.Reading);
        int numberOfRereading = items.Count(i => i.BookLabel == Enums.Label.Rereading);
        int numberOfAbandoned = items.Count(i => i.BookLabel == Enums.Label.Abandoned);
        int NumberOfWantToRead = items.Count(i => i.BookLabel == Enums.Label.ToBeRead);

        var userLabel = Enums.Label.None;

        foreach (var i in user.UserShelf.BookItems)
        {
            if(i.OriginalBookId == book.ID)
            {
                hasbook = true;
                userLabel = i.BookLabel;
                break;
            }
        }
        
        var response = new GetBookDataResponse
        (
            book.Title,
            book.Author,
            book.NumberOfPages,
            book.About,
            rating,
            book.Year,
            book.ImageUrl,
            numberOfFavorites,
            numberOfRead,
            numberOfReading,
            numberOfRereading,
            numberOfAbandoned,
            NumberOfWantToRead,
            userLabel
        );

        return Result<GetBookDataResponse>.Success(response);
    }
}