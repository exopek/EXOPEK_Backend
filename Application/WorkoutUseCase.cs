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
}