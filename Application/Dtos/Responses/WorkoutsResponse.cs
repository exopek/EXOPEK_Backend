using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutsResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string PreviewImageUrl { get; set; }

    public string Hint { get; set; } = "Ich bin das Dto";

    public string Difficulty { get; set; }
    
    public string Category { get; set; }
    
    public string Hashtags { get; set; }

    public double Duration { get; set; }
    public PhaseType PhaseType { get; set; }

    public int Order { get; set; }
    
    public Guid PlanWorkoutId { get; set; }
}