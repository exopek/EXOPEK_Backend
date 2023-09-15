using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutUserCommentRepository
{
    public OperationSingleResult<WorkoutUserComments> CreateWorkoutUserCommentAsync(WorkoutUserComments workoutUserComment, bool trackChanges);
    public Task<IEnumerable<WorkoutUserComments>> GetAllWorkoutUserCommentsByIdAsync(Guid id, bool trackChanges);
}