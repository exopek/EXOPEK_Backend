using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Entities.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<WorkoutUserComments> WorkoutUserComments { get; set; }
    
    public ICollection<WorkoutUserLikes> WorkoutUserLikes { get; set; }
    
    public ICollection<WorkoutUserCompletes> WorkoutUserCompletes { get; set; }
}