using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Application;

public interface IWorkoutUseCase
{
    public Task<OperationListResult<Workout>> GetWorkoutsAsync();
    public Task<OperationSingleResult<Workout>> GetWorkoutAsync(Guid id);
    public Task<OperationSingleResult<WorkoutUserCompletes>> CreateWorkoutUserCompletesAsync(WorkoutCompleteRequest request);
    public Task<OperationSingleResult<bool>> CreateWorkoutUserLikesAsync(WorkoutLikeRequest request);
}