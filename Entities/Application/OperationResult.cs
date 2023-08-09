namespace EXOPEK_Backend.Entities.Application;

public class OperationResult
{
    public bool Success { get; set; }
    
    public IEnumerable<string> Errors { get; set; }
}