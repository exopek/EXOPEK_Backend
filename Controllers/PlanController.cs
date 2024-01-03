using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
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
    public async Task<IActionResult> GetAllPlans([FromQuery] PlansRequest request)
    {
        var plans = await _useCaseManager.Plan.GetPlansAsync(request);
        
        if (!plans.Success)
        {
            return NotFound(plans.Errors);
        }
        
        var plansDto = _mapper.Map<IEnumerable<PlanResponse>>(plans.Items);

        return Ok(plansDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlan([FromRoute] Guid id)
    {
        var plan = await _useCaseManager.Plan.GetPlanAsync(id);
        
        if (!plan.Success)
        {
            return BadRequest(plan.Errors);
        }
        
        var planDto = _mapper.Map<PlanSingleResponse>(plan.Item);

        return Ok(planDto);
    }
    
    [HttpPut("status")]
    public async Task<IActionResult> UpdatePlanStatus(
        [FromBody] PlanStatusRequest request)
    {
        var planUserStatus = await _useCaseManager.Plan.UpdatePlanStatusAsync(request);
        
        if (!planUserStatus.Success)
        {
            return BadRequest(planUserStatus.Errors);
        }
        
        var planUserStatusDto = _mapper.Map<PlanUserStatusResponse>(planUserStatus.Item);

        return Ok(planUserStatusDto);
    }
    
    [HttpPost("status")]
    public async Task<IActionResult> CreatePlanUserStatus(
        [FromBody] PlanStatusRequest request)
    {
        var planUserStatus = await _useCaseManager.Plan.CreatePlanUserStatusAsync(request);
        
        if (!planUserStatus.Success)
        {
            return BadRequest(planUserStatus.Errors);
        }
        
        var planUserStatusDto = _mapper.Map<PlanUserStatusResponse>(planUserStatus.Item);

        return Ok(planUserStatusDto);
    }
    
    [HttpGet("status")]
    public async Task<IActionResult> GetAllPlanUserStatuses(
        [FromQuery] PlanStatusRequest request)
    {
        var planUserStatuses = await _useCaseManager.Plan.GetAllPlanUserStatusesAsync(request);
        
        if (!planUserStatuses.Success)
        {
            return BadRequest(planUserStatuses.Errors);
        }
        
        var planUserStatusesDto = _mapper.Map<IEnumerable<PlanUserStatusResponse>>(planUserStatuses.Items);

        return Ok(planUserStatusesDto);
    }
    
    /*[HttpGet("status/{id:guid}")]
    public async Task<IActionResult> GetPlanUserStatus(
        [FromRoute] Guid id)
    {
        var planUserStatus = await _useCaseManager.Plan.GetPlanUserStatusAsync(id);
        
        if (!planUserStatus.Success)
        {
            return BadRequest(planUserStatus.Errors);
        }
        
        var planUserStatusDto = _mapper.Map<PlanUserStatusResponse>(planUserStatus.Item);

        return Ok(planUserStatusDto);
    }*/
}