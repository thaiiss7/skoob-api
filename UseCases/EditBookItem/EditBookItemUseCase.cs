using Microsoft.EntityFrameworkCore;
using Skoob.Models;

namespace Skoob.UseCases.EditBookItem;

public class EditBookItemUseCase(SkoobDbContext ctx)
{
    public async Task<Result<EditBookItemResponse>> Do(EditBookItemPayload payload)
    {
        var bookitem = await ctx.BookItems
            .FirstOrDefaultAsync(i => i.ID == payload.BookItemId);

        if(bookitem is null)
            return Result<EditBookItemResponse>.Failure("book not found");

        bookitem.Rating = payload.Rating ?? bookitem.Rating;
        bookitem.BookLabel = payload.BookLabel ?? bookitem.BookLabel;
        bookitem.Favorite = payload.Favorite ?? bookitem.Favorite;

        await ctx.SaveChangesAsync();

        return Result<EditBookItemResponse>.Success(new(bookitem.ID));
    }
}