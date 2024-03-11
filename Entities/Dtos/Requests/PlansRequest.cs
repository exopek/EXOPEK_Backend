using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Requests;

public class PlansRequest
{
    public TargetType TargetType { get; set; } = TargetType.None;

    public DifficultyType DifficultyType { get; set; } = DifficultyType.None;

    public string SearchTerm { get; set; } = "";
    
    public string PlanIds { get; set; } = "";
}