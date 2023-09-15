using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutUserCompletesRepository
{
    OperationSingleResult<WorkoutUserCompletes> CreateWorkoutUserCompletes(WorkoutUserCompletes workoutUserCompletes, bool trackChanges);
}