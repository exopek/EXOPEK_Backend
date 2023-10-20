using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Application;

public class PlanUseCase : IPlanUseCase
{
    private readonly IRepositoryManager _repository;
    
    public PlanUseCase(IRepositoryManager repository)
    {
        _repository = repository;
    }
    
    public async Task<OperationListResult<Plan>> GetPlansAsync()
    {
        var plans = await _repository.Plan.GetAllPlansAsync(false);
        return new OperationListResult<Plan>
        {
            Items = plans,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<Plan>> GetPlanAsync(Guid id, Guid? planStatusId)
    {
        var plan = await _repository.Plan.GetPlanAsync(id, planStatusId, false);
        return new OperationSingleResult<Plan>
        {
            Item = plan,
            Success = true
        };
    }
}