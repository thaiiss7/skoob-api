using Microsoft.AspNetCore.Identity;
using Skoob.Models;
using Skoob.Services.Password;
using Skoob.Services.Profiles;

namespace Skoob.UseCases.CreateProfile;

public class CreateProfileUseCase
(
    IProfileService profileService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        var profile = new Profile
        {
            Username = payload.Username,
            Email = payload.Email,
            Password = passwordService.Hash(payload.Password),
            Bio = payload.Bio
        };

        await profileService.Create(profile);

        return Result<CreateProfileResponse>.Success(new());
    }
}