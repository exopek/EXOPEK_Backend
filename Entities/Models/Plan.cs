namespace EXOPEK_Backend.Entities.Models;

public class Plan
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public string PreviewImageUrl { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DifficultyType Difficulty { get; set; }
    
    public TargetType Target { get; set; }
    
    public string? Hashtags { get; set; }
    
    public string? VideoUrl { get; set; }

    public double Duration { get; set; }
    
    public ICollection<PlanWorkout> PlanWorkouts { get; set; } = new List<PlanWorkout>();
    
    public ICollection<PlanUserStatus> PlanUserStatus { get; set; } = new List<PlanUserStatus>();
}