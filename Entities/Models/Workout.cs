using EXOPEK_Backend.Entities.BaseModels;

namespace EXOPEK_Backend.Entities.Models;

public class Workout
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Image> Images { get; set; } = new List<Image>();
    public ICollection<Video> Videos { get; set; } = new List<Video>();
}