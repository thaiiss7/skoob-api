using Microsoft.EntityFrameworkCore;
using Skoob.Models;

namespace Skoob.UseCases.GetProfileData;

public class GetProfileDataUseCase(SkoobDbContext ctx)
{
    public async Task<Result<GetProfileDataResponse>> Do(GetProfileDataPayload payload)
    {
        var profile = await ctx.Profiles
        .Include(p => p.UserShelf)
            .ThenInclude(s => s.TBRs)
        .FirstOrDefaultAsync(p => p.Username == payload.Username);

        if (profile is null)
            return Result<GetProfileDataResponse>.Failure("User not found");
        
        var tbr = await ctx.TBRs
        .Where(t => t.Year == DateTime.Now.Year)
        .FirstOrDefaultAsync(t => t.ShelfId == profile.ShelfId);

        var response = new GetProfileDataResponse
        (
            profile.Username,
            profile.Bio,
            tbr,
            from r in profile.ReadingLogs
            select new ReadingLogData
            (
                r.User.Username,
                r.Time,
                r.PagesRead,
                r.BookRead.Original.Title
            )
        );

        return Result<GetProfileDataResponse>.Success(response);
    }
}