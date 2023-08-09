namespace EXOPEK_Backend.Application.Dtos.Responses;

public class WorkoutsResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public string Hint { get; set; } = "Ich bin das Dto";
}