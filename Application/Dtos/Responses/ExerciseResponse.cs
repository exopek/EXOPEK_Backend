using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Responses;

public class ExerciseResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string VideoUrl { get; set; }
    
    public string PreviewImageUrl { get; set; }
    
    public string CreatedAt { get; set; }
    
    public string Difficulty { get; set; }
    
    public string Category { get; set; }
    
    public int Duration { get; set; }
    
    public int Reps { get; set; }
    
    public int StageOrder { get; set; }
    
    public int StageRound { get; set; }
    
    public StageType StageType { get; set; }
    
}