using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Application;

public interface IPlanUseCase
{
    public Task<OperationListResult<Plan>> GetPlansAsync(PlansRequest request);
    public Task<OperationSingleResult<Plan>> GetPlanAsync(Guid id);
    
    public Task<OperationSingleResult<PlanUserStatus>> UpdatePlanStatusAsync(PlanStatusRequest request);
    
    public Task<OperationSingleResult<PlanUserStatus>> CreatePlanUserStatusAsync(PlanStatusRequest request);
    
    public Task<OperationListResult<PlanUserStatus>> GetAllPlanUserStatusesAsync(PlanStatusRequest request);
}