using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EXOPEK_Backend.Controllers;

[ApiController]
[Route("api/plans")]

public class PlanController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IUseCaseManager _useCaseManager;
    private readonly IMapper _mapper;
    
    public PlanController(IRepositoryManager repository, IMapper mapper, IUseCaseManager useCaseManager)
    {
        _repository = repository;
        _useCaseManager = useCaseManager;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPlans()
    {
        var plans = await _useCaseManager.Plan.GetPlansAsync();
        
        if (!plans.Success)
        {
            return NotFound(plans.Errors);
        }
        
        var plansDto = _mapper.Map<IEnumerable<PlanResponse>>(plans.Items);

        return Ok(plansDto);
    }
    
    [HttpGet("byId")]
    public async Task<IActionResult> GetPlan(
        [FromQuery] Guid id, Guid? planStatusId)
    {
        var plan = await _useCaseManager.Plan.GetPlanAsync(id, planStatusId);
        
        if (!plan.Success)
        {
            return NotFound(plan.Errors);
        }
        
        var planDto = _mapper.Map<PlanSingleResponse>(plan.Item);

        return Ok(planDto);
    }
}