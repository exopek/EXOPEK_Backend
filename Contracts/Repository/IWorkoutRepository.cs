using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IWorkoutRepository
{
    public Task<IEnumerable<Workout>> GetAllWorkoutsAsync(WorkoutsRequest request, bool trackChanges);
    public Task<Workout> GetWorkoutAsync(Guid id, bool trackChanges);
}