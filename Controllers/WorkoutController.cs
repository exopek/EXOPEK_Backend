using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EXOPEK_Backend.Controllers;

[ApiController]
[Route("api/workouts")]

public class WorkoutController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IUseCaseManager _useCaseManager;
    private readonly IMapper _mapper;

    public WorkoutController(IRepositoryManager repository, IMapper mapper, IUseCaseManager useCaseManager)
    {
        _repository = repository;
        _useCaseManager = useCaseManager;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkouts()
    {
        var workouts = await _useCaseManager.Workout.GetWorkoutsAsync();
        
        if (!workouts.Success)
        {
            return NotFound(workouts.Errors);
        }
        
        var workoutsDto = _mapper.Map<IEnumerable<WorkoutsResponse>>(workouts.Items);

        var test = workouts;
        
        return Ok(workoutsDto);
    }
    
    [HttpGet("byId")]
    public async Task<IActionResult> GetWorkout(
        [FromQuery] Guid id)
    {
        var workout = await _useCaseManager.Workout.GetWorkoutAsync(id);
        
        if (!workout.Success)
        {
            return NotFound(workout.Errors);
        }
        
        var workoutDto = _mapper.Map<WorkoutSingleResponse>(workout.Item);

        return Ok(workoutDto);
    }
}