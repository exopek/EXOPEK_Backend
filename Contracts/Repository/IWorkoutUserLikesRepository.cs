using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutUserLikesRepository
{
    public void CreateWorkoutUserLike(WorkoutUserLikes workoutUserLike, bool trackChanges);
    
    public void DeleteWorkoutUserLike(WorkoutUserLikes workoutUserLike, bool trackChanges);
    
    public Task<WorkoutUserLikes> GetWorkoutUserLikeAsync(Guid id, bool trackChanges);
    
    public Task<IEnumerable<WorkoutUserLikes>> GetAllWorkoutUserLikesByUserIdAsync(Guid id, bool trackChanges);
}