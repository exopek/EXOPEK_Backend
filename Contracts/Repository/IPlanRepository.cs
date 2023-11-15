using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IPlanRepository
{
    public Task<IEnumerable<Plan>> GetAllPlansAsync(bool trackChanges, PlansRequest request);
    public Task<Plan> GetPlanAsync(Guid id, bool trackChanges);
}