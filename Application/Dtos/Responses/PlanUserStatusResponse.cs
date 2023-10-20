using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Responses;

public class PlanUserStatusResponse
{
    public string Id { get; set; }
    
    public PhaseType CurrentPhase { get; set; }
}