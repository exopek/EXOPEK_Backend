using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Application.Dtos.Requests;

public class WorkoutsRequest
{
    public CategoryType CategoryType { get; set; } = CategoryType.None;

    public DifficultyType DifficultyType { get; set; } = DifficultyType.None;

    public string SearchTerm { get; set; } = "";
}