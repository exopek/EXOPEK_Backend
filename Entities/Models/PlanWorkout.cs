namespace EXOPEK_Backend.Entities.Models;

public class PlanWorkout
{
    public Guid Id { get; set; }
    
    public Guid PlanId { get; set; }
    
    public Plan Plan { get; set; }
    
    public Guid WorkoutId { get; set; }
    
    public Workout Workout { get; set; }
    
    public PhaseType PhaseType { get; set; }
    
    public int Order { get; set; }
}