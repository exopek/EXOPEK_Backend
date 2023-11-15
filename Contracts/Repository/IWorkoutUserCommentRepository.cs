using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutUserCommentRepository
{
    public void CreateWorkoutUserCommentAsync(WorkoutUserComments workoutUserComment, bool trackChanges);
    public Task<IEnumerable<WorkoutUserComments>> GetAllWorkoutUserCommentsByWorkoutIdAsync(Guid id, bool trackChanges);
    
    public void DeleteWorkoutUserComment(WorkoutUserComments workoutUserComment, bool trackChanges);
    
    public Task<WorkoutUserComments> GetWorkoutUserCommentAsync(Guid id, bool trackChanges);
}