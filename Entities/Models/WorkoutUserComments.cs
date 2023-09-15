namespace EXOPEK_Backend.Entities.Models;

public class WorkoutUserComments
{
    public Guid Id { get; set; }
    
    public Guid WorkoutId { get; set; }
    
    public Workout Workout { get; set; }
    
    //public Guid UserId { get; set; }
    
    public User User { get; set; } // Über das Framework wird die UserId automatisch mitgegeben
    
    public string Comment { get; set; }
    
    public DateTime CreatedAt { get; set; }
}