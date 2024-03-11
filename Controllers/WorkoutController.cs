using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> GetAllWorkouts(
        [FromQuery] WorkoutsRequest request)
    {
        var workouts = await _useCaseManager.Workout.GetWorkoutsAsync(request);
        
        if (!workouts.Success)
        {
            return NotFound(workouts.Errors);
        }
        
        var workoutsDto = _mapper.Map<IEnumerable<WorkoutsResponse>>(workouts.Items);

        var test = workouts;
        
        return Ok(workoutsDto);
    }
    
    [HttpGet("byId")] // ToDo: Refactoring
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
    
    [Authorize]
    [HttpPost("completes")]
    public async Task<IActionResult> CreateWorkoutUserCompletes(
        [FromBody] WorkoutCompleteRequest request)
    {
        var workoutUserCompletes = await _useCaseManager.Workout.CreateWorkoutUserCompletesAsync(request);
        
        if (!workoutUserCompletes.Success)
        {
            return BadRequest(workoutUserCompletes.Errors);
        }
        
        var workoutUserCompletesDto = _mapper.Map<WorkoutUserCompletesResponse>(workoutUserCompletes.Item);

        return Ok(workoutUserCompletesDto);
    }

    [Authorize]
    [HttpPost("likes")]
    public async Task<IActionResult> CreateWorkoutUserLikes(
        [FromBody] WorkoutLikeRequest request)
    {
        var workoutUserLikes = await _useCaseManager.Workout.CreateWorkoutUserLikesAsync(request);
        
        if (!workoutUserLikes.Success)
        {
            return BadRequest(workoutUserLikes.Errors);
        }

        return Ok();
    }
    
    [HttpDelete("likes/{id:guid}")]
    public async Task<IActionResult> DeleteWorkoutUserLikes(
        [FromRoute] Guid id)
    {
        await _useCaseManager.Workout.DeleteWorkoutUserLike(id);

        return Ok();
    }
    
    [HttpGet("likes")]
    public async Task<IActionResult> GetAllWorkoutUserLikesByUserId(
        [FromQuery] Guid id)
    {
        var workoutUserLikes = await _useCaseManager.Workout.GetAllWorkoutUserLikesByUserIdAsync(id);

        var workoutUserLikesDto = _mapper.Map<IEnumerable<WorkoutUserLikesResponse>>(workoutUserLikes.Items);

        return Ok(workoutUserLikesDto);
    }
    
    [HttpPost("comments")]
    public async Task<IActionResult> CreateWorkoutUserComments(
        [FromBody] WorkoutCommentRequest request)
    {
        var workoutUserComments = await _useCaseManager.Workout.CreateWorkoutUserCommentAsync(request);
        
        if (!workoutUserComments.Success)
        {
            return BadRequest(workoutUserComments.Errors);
        }
        
        var workoutUserCommentsDto = _mapper.Map<WorkoutUserCommentsResponse>(workoutUserComments.Item);

        return Ok(workoutUserCommentsDto);
    }
    
    [HttpDelete("comments/{id:guid}")]
    public async Task<IActionResult> DeleteWorkoutUserCommentsByCommentId(
        [FromRoute] Guid id)
    {
        await _useCaseManager.Workout.DeleteWorkoutUserComment(id);

        return Ok();
    }
    
    [HttpGet("comments")]
    public async Task<IActionResult> GetAllWorkoutUserCommentsByWorkoutId(
        [FromQuery] Guid id)
    {
        var workoutUserComments = await _useCaseManager.Workout.GetAllWorkoutUserCommentsByWorkoutIdAsync(id);

        var workoutUserCommentsDto = _mapper.Map<IEnumerable<WorkoutUserCommentsResponse>>(workoutUserComments.Items);

        return Ok(workoutUserCommentsDto);
    }
}