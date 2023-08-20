namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutSingleResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string PreviewImage { get; set; }
    
    public string CreatedAt { get; set; }
    
    public string Difficulty { get; set; }
    
    public string Category { get; set; }
    
    public string Hashtags { get; set; }
    
    public string VideoUrl { get; set; }
    
    public string MuscleImageUrl { get; set; }
    
    public double Duration { get; set; }
    
    public string Hint { get; set; } = "Ich bin das SingleDto";
    
    public ICollection<ExerciseResponse> Exercises { get; set; } = new List<ExerciseResponse>();
}