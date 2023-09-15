namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutUserCompletesResponse
{
    public Guid Id { get; set; }
    
    public bool IsCompleted { get; set; }
}