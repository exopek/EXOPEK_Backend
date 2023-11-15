
namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutUserCommentsResponse
{
    public Guid Id { get; set; }
    
    public UserResponse User { get; set; }
    
    public string Comment { get; set; }
    
    public string CreatedAt { get; set; }
}