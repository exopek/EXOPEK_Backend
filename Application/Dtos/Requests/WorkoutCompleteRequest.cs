namespace EXOPEK_Backend.Application.Dtos.Requests;

public class WorkoutCompleteRequest
{
    public Guid WorkoutId { get; set; }
    
    public Guid UserId { get; set; }
}