using System.ComponentModel.DataAnnotations;

namespace Skoob.UseCases.CreateProfile;

public record CreateProfilePayload
{
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string Username { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [MinLength(6)]
    // validação de número
    public string Password { get; init; }

    [Required]
    [Compare("Password")]
    public string RepeatPassword { get; init; }

    [MaxLength(200)]
    public string ?Bio { get; init; }   
}