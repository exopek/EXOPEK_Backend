
namespace EXOPEK_Backend.Entities.Models;

public class JwtSettings
{
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public string AccessTokenSecret { get; set; }
    
    public TimeSpan AccessTokenLifetime { get; set; }
}