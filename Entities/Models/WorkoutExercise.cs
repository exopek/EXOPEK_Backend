
namespace EXOPEK_Backend.Entities.Models;

public class WorkoutExercise
{
    public Guid Id { get; set; }
    
    public Guid WorkoutId { get; set; }
    public Workout Workout { get; set; }
    
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    public int StageRound { get; set; }
    
    public int StageOrder { get; set; }
    
    public int? Reps { get; set; }
    
    public int? Duration { get; set; }
    
    public StageType StageType { get; set; }
}