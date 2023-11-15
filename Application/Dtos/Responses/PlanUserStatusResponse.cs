using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Responses;

public class PlanUserStatusResponse
{
    public string Id { get; set; }
    
    public PhaseType CurrentPhase { get; set; }
    
    public StatusType Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public ICollection<string> WorkoutIds { get; set; } = new List<string>();
    
}