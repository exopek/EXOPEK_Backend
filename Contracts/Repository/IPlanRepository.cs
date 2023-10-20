using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IPlanRepository
{
    public Task<IEnumerable<Plan>> GetAllPlansAsync(bool trackChanges);
    public Task<Plan> GetPlanAsync(Guid id, Guid? planStatusId, bool trackChanges);
}