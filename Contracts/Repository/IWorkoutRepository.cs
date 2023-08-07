using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutRepository
{
    public Task<IEnumerable<Workout>> GetAllWorkoutsAsync(bool trackChanges);
}