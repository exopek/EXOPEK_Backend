using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutUserLikesRepository
{
    public OperationSingleResult<WorkoutUserLikes> CreateWorkoutUserLike(WorkoutUserLikes workoutUserLike, bool trackChanges);
}