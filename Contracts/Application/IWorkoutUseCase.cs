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
    public Task<OperationSingleResult<WorkoutUserComments>> CreateWorkoutUserCommentAsync(WorkoutCommentRequest request);
    
    public Task<OperationSingleResult<bool>> DeleteWorkoutUserComment(Guid id);
    
    public Task<OperationListResult<WorkoutUserComments>> GetAllWorkoutUserCommentsByWorkoutIdAsync(Guid id);
    
    public Task<OperationListResult<WorkoutUserLikes>> GetAllWorkoutUserLikesByUserIdAsync(Guid id);
    
    public Task<OperationSingleResult<bool>> DeleteWorkoutUserLike(Guid id);
}