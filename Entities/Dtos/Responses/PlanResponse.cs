namespace EXOPEK_Backend.Application.Dtos.Responses;

public class PlanResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }

    public string PreviewImageUrl { get; set; }

    public string Hint { get; set; } = "Ich bin das Dto Plan";

    public string Difficulty { get; set; }
    
    public string Target { get; set; }
    
    public string Hashtags { get; set; }

    public double Duration { get; set; }
    
    public string VideoUrl { get; set; }
}