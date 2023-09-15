namespace EXOPEK_Backend.Entities.Models;

public class Workout
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public string PreviewImageUrl { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DifficultyType Difficulty { get; set; }
    
    public CategoryType Category { get; set; }
    
    public string Hashtags { get; set; } // Vllt nullable machen
    
    public string? VideoUrl { get; set; }
    
    public string? MuscleImageUrl { get; set; }
    
    public double Duration { get; set; }
    public ICollection<Image> Images { get; set; } = new List<Image>();
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    
    public int Likes { get; set; }
    
    public int Comments { get; set; }
    public ICollection<WorkoutUserComments> WorkoutUserComments { get; set; } = new List<WorkoutUserComments>();
    
    public ICollection<WorkoutUserLikes> WorkoutUserLikes { get; set; } = new List<WorkoutUserLikes>();
    
    public ICollection<WorkoutUserCompletes> WorkoutUserCompletes { get; set; } = new List<WorkoutUserCompletes>();


}