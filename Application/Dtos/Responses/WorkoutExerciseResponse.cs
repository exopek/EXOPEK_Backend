namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutExerciseResponse
{
    public string Id { get; set; }
    
    public int Duration { get; set; }
    
    public int Reps { get; set; }
    
    public int StageOrder { get; set; }
    
    public int StageRound { get; set; }
    
    public string StageType { get; set; }
    
    public ICollection<ExerciseResponse> Exercises { get; set; } = new List<ExerciseResponse>();
    
}