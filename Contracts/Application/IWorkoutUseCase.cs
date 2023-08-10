using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Application;

public interface IWorkoutUseCase
{
    public Task<OperationListResult<Workout>> GetWorkoutsAsync();
    public Task<OperationSingleResult<Workout>> GetWorkoutAsync(Guid id);
}