namespace EXOPEK_Backend.Entities.Models;

public class Exercise
{
    public Guid Id { get; set; }
    
    public string VideoUrl { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}