namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutUserLikesResponse
{
    public string Id { get; set; }
    
    public string UserId { get; set; }
    
    public bool IsLiked { get; set; }
    
    public string CreatedAt { get; set; }
    
    public string WorkoutId { get; set; }
    
}
