using Skoob.Models;

namespace Skoob.Services.Profiles;

public interface IProfileService
{
    Task<Profile> FindByLogin(string login);
    Task<Guid> Create(Profile profile);
}