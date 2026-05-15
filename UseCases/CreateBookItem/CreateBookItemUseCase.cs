using Skoob.Models;
using Skoob.Enums;
using Microsoft.EntityFrameworkCore;

namespace Skoob.UseCases.CreateBookItem;

public class CreateBookItemUseCase(SkoobDbContext ctx)
{
    public async Task<Result<CreateBookItemResponse>> Do(CreateBookItemPayload payload)
    {
        var shelf = await ctx.Bookshelves.FirstOrDefaultAsync(s => s.OwnerId == payload.ProfileId);

        if(shelf is null)
            return Result<CreateBookItemResponse>.Failure("shelf not found");
        
        var bookItem = new BookItem
        {
            BookLabel = payload.BookLabel,
            OriginalBookId = payload.BookId,
            OwnerId = payload.ProfileId,
            ShelfId = shelf.ID,
        };

        ctx.BookItems.Add(bookItem);
        await ctx.SaveChangesAsync();

        return Result<CreateBookItemResponse>.Success(new(bookItem.ID));
    }
}