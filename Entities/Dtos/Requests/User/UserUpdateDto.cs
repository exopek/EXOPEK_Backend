namespace EXOPEK_Backend.Application.Dtos.Requests;

public class UserUpdateDto
{
    public string? FirstName { get; init; }
    
    public string? LastName { get; init; }
    
    public string? ImageUrl { get; init; }
    
    public int? Age { get; init; }
    
    public double? Height { get; init; }
    
    public double? Weight { get; init; }
    
    public int? PreviousTrainingFrequency { get; init; }
    
    public int? TrainingFrequency { get; init; }
    
    public int? SportType { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    public string? Email { get; init; }
    
    public string? UserName { get; init; }
    
    public string? Password { get; init; }
}