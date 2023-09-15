using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Application;

public class WorkoutUseCase : IWorkoutUseCase
{
    
    private readonly IRepositoryManager _repository;
    public WorkoutUseCase(IRepositoryManager repository)
    {
        _repository = repository;
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
}