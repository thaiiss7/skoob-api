using Microsoft.EntityFrameworkCore;
using Skoob.Models;

namespace Skoob.Services.Profiles;

public class EFProfileService(SkoobDbContext ctx) : IProfileService
{
    public async Task<Guid> Create(Profile profile)
    {
        ctx.Profiles.Add(profile);
        await ctx.SaveChangesAsync();
        return profile.ID;
    }

    public async Task<Profile> FindByLogin(string login)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(
            p => p.Username == login || p.Email == login
        );
        return profile;
    }
}