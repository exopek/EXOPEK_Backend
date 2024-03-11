namespace EXOPEK_Backend.Application.Dtos.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    
    public string UserName { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Password { get; set; }
}