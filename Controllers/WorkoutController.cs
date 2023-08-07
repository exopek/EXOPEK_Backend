using EXOPEK_Backend.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EXOPEK_Backend.Controllers;

[ApiController]
[Route("api/workouts")]

public class WorkoutController : ControllerBase
{
    private readonly IRepositoryManager _repository;

    public WorkoutController(IRepositoryManager repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkouts()
    {
        var workouts = await _repository.Workout.GetAllWorkoutsAsync(trackChanges: false);

        var test = workouts;
        
        return Ok(workouts);
    }
}