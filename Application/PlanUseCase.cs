using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Application;

public class PlanUseCase : IPlanUseCase
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;

    public PlanUseCase(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }
    
    public async Task<OperationListResult<Plan>> GetPlansAsync(PlansRequest request)
    {
        var plans = await _repository.Plan.GetAllPlansAsync(false, request);
        return new OperationListResult<Plan>
        {
            Items = plans,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<Plan>> GetPlanAsync(Guid id)
    {
        var plan = await _repository.Plan.GetPlanAsync(id, false);
        return new OperationSingleResult<Plan>
        {
            Item = plan,
            Success = true
        };
    }

    public async Task<OperationSingleResult<PlanUserStatus>> UpdatePlanStatusAsync(PlanStatusRequest request)
    {
        if (request.Id.Equals(Guid.Empty) || request.Id == null)
        {
            return new OperationSingleResult<PlanUserStatus>
            {
                Success = false,
                Errors = new List<string> {"Id is empty"} 
            };
        }
        
        var planUserStatus = await _repository.PlanUserStatus.GetPlanUserStatusAsync(request.Id.Value, false);
        
        if (planUserStatus == null)
        {
            return new OperationSingleResult<PlanUserStatus>
            {
                Success = false,
                Errors = new List<string> {"PlanUserStatus not found"} 
            };
        }

        if (!request.Status.HasValue)
        {
            return new OperationSingleResult<PlanUserStatus>
            {
                Success = false,
                Errors = new List<string> {"StatusType not set"} 
            };
        }
        planUserStatus.Status = request.Status.Value;

        if (!request.CurrentPhase.HasValue)
        {
            return new OperationSingleResult<PlanUserStatus>
            {
                Success = false,
                Errors = new List<string> {"CurrentPhaseType not set"} 
            };
        }
        
        planUserStatus.CurrentPhase = request.CurrentPhase.Value;

        if (request.WorkoutsIds.Count > 0)
        {
            var workoutIdsAsString = request.WorkoutsIds.Aggregate("", (current, workoutId) => current + (workoutId + ","));
            planUserStatus.WorkoutIds = workoutIdsAsString;
        }
        
        _repository.PlanUserStatus.UpdatePlanUserStatus(planUserStatus, true);
        
        await _repository.SaveAsync();

        return new OperationSingleResult<PlanUserStatus>
        {
            Item = planUserStatus,
            Success = true
        };
    }

    public async Task<OperationSingleResult<PlanUserStatus>> CreatePlanUserStatusAsync(PlanStatusRequest request)
    {

        var user = _userManager.FindByIdAsync(request.UserId.ToString()).Result;
        
        var planUserStatus = new PlanUserStatus
        {
            Id = Guid.NewGuid(),
            PlanId = request.PlanId.Value,
            User = user,
            Status = StatusType.Active,
            CurrentPhase = PhaseType.Phase1
        };

        _repository.PlanUserStatus.CreatePlanUserStatus(planUserStatus, false);
        
        await _repository.SaveAsync();

        return new OperationSingleResult<PlanUserStatus>
        {
            Item = planUserStatus,
            Success = true
        };
    }

    public async Task<OperationListResult<PlanUserStatus>> GetAllPlanUserStatusesAsync(PlanStatusRequest request)
    {
        var planUserStatuses = await _repository.PlanUserStatus.GetAllPlanUserStatusesAsync(request, false);
        return new OperationListResult<PlanUserStatus>
        {
            Items = planUserStatuses,
            Success = true
        };
    }
}