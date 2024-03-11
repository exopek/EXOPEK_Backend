namespace EXOPEK_Backend.Application.Dtos.Responses;

public class UserRegistrationResult
{
    public UserResponse User { get; set; }

    public string Token { get; set; }
}