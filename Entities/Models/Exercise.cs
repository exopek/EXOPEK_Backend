namespace EXOPEK_Backend.Entities.Models;



public class Exercise
{
    public Guid Id { get; set; }
    
    public string VideoUrl { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public string PreviewImageUrl { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DifficultyType Difficulty { get; set; }
    
    public CategoryType Category { get; set; }
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}