using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Application;

public class WorkoutUseCase : IWorkoutUseCase
{
    
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;
    public WorkoutUseCase(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }
    public async Task<OperationListResult<Workout>> GetWorkoutsAsync()
    {
        var workouts = await _repository.Workout.GetAllWorkoutsAsync(trackChanges: false);
        
        if (!workouts.Any())
        {
            return new OperationListResult<Workout>
            {
                Success = false,
                Errors = new List<string> {"No workouts found"}
            };
        }

        return new OperationListResult<Workout>
        {
            Items = workouts,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<Workout>> GetWorkoutAsync(Guid id)
    {
        var workout = await _repository.Workout.GetWorkoutAsync(id, trackChanges: false);
        
        if (workout.Equals(null))
        {
            return new OperationSingleResult<Workout>
            {
                Success = false,
                Errors = new List<string> {"Workout not found"}
            };
        }

        return new OperationSingleResult<Workout>
        {
            Item = workout,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<WorkoutUserCompletes>> CreateWorkoutUserCompletesAsync(WorkoutCompleteRequest request)
    {
        var User = await _userManager.FindByIdAsync(request.UserId.ToString());
        
        if (User.Equals(null))
        {
            return new OperationSingleResult<WorkoutUserCompletes>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }
        
        var workoutUserCompletes = new WorkoutUserCompletes
        {
            WorkoutId = request.WorkoutId,
            CreatedAt = DateTime.UtcNow,
            User = User,
            IsCompleted = true
        };
        
        var workoutUserCompletesResult = _repository.WorkoutUserCompletes.CreateWorkoutUserCompletes(workoutUserCompletes, trackChanges: false);
        
        if (!workoutUserCompletesResult.Success)
        {
            return new OperationSingleResult<WorkoutUserCompletes>
            {
                Success = false,
                Errors = new List<string> {"WorkoutUserCompletes not created"}
            };
        }

        await _repository.SaveAsync();

        return new OperationSingleResult<WorkoutUserCompletes>
        {
            Item = workoutUserCompletesResult.Item,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<bool>> CreateWorkoutUserLikesAsync(WorkoutLikeRequest request)
    {
        var User = await _userManager.FindByIdAsync(request.UserId.ToString());
        
        if (User.Equals(null))
        {
            return new OperationSingleResult<bool>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }
        
        var workoutUserLikes = new WorkoutUserLikes
        {
            WorkoutId = request.WorkoutId,
            CreatedAt = DateTime.UtcNow,
            User = User,
            IsLiked = true
        };
        
        _repository.WorkoutUserLikes.CreateWorkoutUserLike(workoutUserLikes, trackChanges: false);

        await _repository.SaveAsync();

        return new OperationSingleResult<bool>
        {
            Success = true
        };
    }
}