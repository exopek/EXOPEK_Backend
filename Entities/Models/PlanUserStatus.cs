namespace EXOPEK_Backend.Entities.Models;

public class PlanUserStatus
{
    public Guid Id { get; set; }
    
    public Guid PlanId { get; set; }
    
    public Plan Plan { get; set; }
    public User User { get; set; }
    
    public PhaseType CurrentPhase { get; set; }
    
    public string WorkoutIds { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public StatusType Status { get; set; }
    
    public int ProgressPercentage { get; set; } = 0;
}