namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutSingleResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string PreviewImage { get; set; }
    
    public string Hint { get; set; } = "Ich bin das SingleDto";
    
    public ICollection<ExerciseResponse> Exercises { get; set; } = new List<ExerciseResponse>();
}