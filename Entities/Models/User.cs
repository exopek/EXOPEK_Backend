using EXOPEK_Backend.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Entities.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? ImageUrl { get; set; }
    
    public int? Age { get; set; }
    
    public double? Height { get; set; }
    
    public double? Weight { get; set; }
    
    public int? PreviousTrainingFrequency { get; set; }
    
    public int? TrainingFrequency { get; set; }
    
    public SportType? SportType { get; set; }
    
    public ICollection<WorkoutUserComments> WorkoutUserComments { get; set; }

    public ICollection<WorkoutUserLikes> WorkoutUserLikes { get; set; }

    public ICollection<WorkoutUserCompletes> WorkoutUserCompletes { get; set; }

    public ICollection<PlanUserStatus> PlanUserStatus { get; set; }
}