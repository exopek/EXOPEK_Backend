using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Requests;

public class PlanStatusRequest
{
    public Guid? Id { get; set; }
    // test
    
    public Guid? PlanId { get; set; }
    
    public Guid? UserId { get; set; }
    public StatusType? Status { get; set; }
    public PhaseType? CurrentPhase { get; set; }
    
    public List<string> PlanWorkoutIds { get; set; } = new List<string>();
}