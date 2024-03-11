using System.ComponentModel.DataAnnotations;

namespace EXOPEK_Backend.Application.Dtos.Requests;

public record UserAuthenticationRequest
{
    [Required(ErrorMessage = "User name is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password name is required")]
    public string? Password { get; init; }
}