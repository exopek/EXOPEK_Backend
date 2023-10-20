using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Application;

public interface IPlanUseCase
{
    public Task<OperationListResult<Plan>> GetPlansAsync();
    public Task<OperationSingleResult<Plan>> GetPlanAsync(Guid id, Guid? planStatusId);
}