using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Entities.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}