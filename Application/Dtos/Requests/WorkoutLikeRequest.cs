namespace EXOPEK_Backend.Application.Dtos.Requests;

public class WorkoutLikeRequest
{
    public Guid WorkoutId { get; set; }

    public Guid UserId { get; set; }
    
    public bool IsLiked { get; set; }
}