namespace EXOPEK_Backend.Application.Dtos.Responses;

public class PlanSingleResponse
{
    public string Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string PreviewImageUrl { get; set; }
    
    public string CreatedAt { get; set; }
    
    public string Difficulty { get; set; }
    
    public string Target { get; set; }
    
    public string Hashtags { get; set; }
    
    public string VideoUrl { get; set; }

    public double Duration { get; set; }
    
    public string Hint { get; set; } = "Ich bin das SingleDto";
    public ICollection<WorkoutsResponse> Workouts { get; set; } = new List<WorkoutsResponse>();
    
    public int CurrentPhase { get; set; }
}