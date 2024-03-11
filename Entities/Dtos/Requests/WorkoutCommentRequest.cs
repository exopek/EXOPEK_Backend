namespace EXOPEK_Backend.Application.Dtos.Requests;

public class WorkoutCommentRequest
{
    public Guid Id { get; set; } = new Guid();
    public Guid WorkoutId { get; set; } = new Guid();
    public Guid? UserId { get; set; }

    public string? Comment { get; set; }
}