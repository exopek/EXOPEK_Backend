using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Application;

public class WorkoutUseCase : IWorkoutUseCase
{
    
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;
    private readonly HttpContext _httpContext;
    public WorkoutUseCase(IRepositoryManager repository, UserManager<User> userManager, IHttpContextAccessor httpContext)
    {
        _repository = repository;
        _userManager = userManager;
        _httpContext = httpContext.HttpContext;
    }
    public async Task<OperationListResult<Workout>> GetWorkoutsAsync(WorkoutsRequest request)
    {
        var workouts = await _repository.Workout.GetAllWorkoutsAsync(request, trackChanges: false);

        return new OperationListResult<Workout>
        {
            Items = workouts,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<Workout>> GetWorkoutAsync(Guid id)
    {
        var workout = await _repository.Workout.GetWorkoutAsync(id, trackChanges: false);
        
        if (workout.Equals(null))
        {
            return new OperationSingleResult<Workout>
            {
                Success = false,
                Errors = new List<string> {"Workout not found"}
            };
        }

        return new OperationSingleResult<Workout>
        {
            Item = workout,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<WorkoutUserCompletes>> CreateWorkoutUserCompletesAsync(WorkoutCompleteRequest request)
    {
        var userClaim = _httpContext.User;
        var res = _userManager.Users
            .FirstOrDefault(y => y.UserName.ToLower().Equals(userClaim.Identity.Name.ToLower()));
        var userId = Guid.Parse(res.Id);
        
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user == null)
        {
            return new OperationSingleResult<WorkoutUserCompletes>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }
        
        var workoutUserCompletes = new WorkoutUserCompletes
        {
            WorkoutId = request.WorkoutId,
            CreatedAt = DateTime.UtcNow,
            User = user,
            IsCompleted = true
        };
        
        var workoutUserCompletesResult = _repository.WorkoutUserCompletes.CreateWorkoutUserCompletes(workoutUserCompletes, trackChanges: false);
        
        if (!workoutUserCompletesResult.Success)
        {
            return new OperationSingleResult<WorkoutUserCompletes>
            {
                Success = false,
                Errors = new List<string> {"WorkoutUserCompletes not created"}
            };
        }

        await _repository.SaveAsync();

        return new OperationSingleResult<WorkoutUserCompletes>
        {
            Item = workoutUserCompletesResult.Item,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<WorkoutUserLikes>> CreateWorkoutUserLikesAsync(WorkoutLikeRequest request)
    {
        var userClaim = _httpContext.User;
        var res = _userManager.Users
            .FirstOrDefault(y => y.UserName.ToLower().Equals(userClaim.Identity.Name.ToLower()));
        var userId = Guid.Parse(res.Id);
        
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        var workout = await _repository.Workout.GetWorkoutAsync(request.WorkoutId, trackChanges: true);
        
        if (user.Equals(null))
        {
            return new OperationSingleResult<WorkoutUserLikes>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }
        
        if (workout.Equals(null))
        {
            return new OperationSingleResult<WorkoutUserLikes>
            {
                Success = false,
                Errors = new List<string> {"Workout not found"}
            };
        }
        
        var workoutUserLikes = new WorkoutUserLikes
        {
            WorkoutId = request.WorkoutId,
            CreatedAt = DateTime.UtcNow,
            User = user,
            IsLiked = true
        };
        
        _repository.WorkoutUserLikes.CreateWorkoutUserLike(workoutUserLikes, trackChanges: false);
        
        if (!workoutUserLikes.Id.Equals(Guid.Empty))
        {
            // Update Workout Likes
            workout.Likes += 1;
        }

        await _repository.SaveAsync();
        
        var currentWorkoutUserLike = await _repository.WorkoutUserLikes.GetAllWorkoutUserLikesByWorkoutAndUserIdAsync(userId, workout.Id, false);
        
        if (!currentWorkoutUserLike.Any())
        {
            return new OperationSingleResult<WorkoutUserLikes>
            {
                Success = false,
                Errors = new List<string> {"WorkoutUserLikes not created"}
            };
        }

        return new OperationSingleResult<WorkoutUserLikes>
        {
            Success = true,
            Item = currentWorkoutUserLike.First()
        };
    }

    public async Task<OperationSingleResult<WorkoutUserComments>> CreateWorkoutUserCommentAsync(WorkoutCommentRequest request)
    {
        var userClaim = _httpContext.User;
        var res = _userManager.Users
            .FirstOrDefault(y => y.UserName.ToLower().Equals(userClaim.Identity.Name.ToLower()));
        var userId = Guid.Parse(res.Id);
        
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (request.WorkoutId.Equals(Guid.Empty))
        {
            return new OperationSingleResult<WorkoutUserComments>
            {
                Success = false,
                Errors = new List<string> {"WorkoutId is empty"}
            };
        }
        
        var workout = await _repository.Workout.GetWorkoutAsync(request.WorkoutId, trackChanges: true);
        
        if (user.Equals(null))
        {
            return new OperationSingleResult<WorkoutUserComments>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }
        
        if (workout.Equals(null))
        {
            return new OperationSingleResult<WorkoutUserComments>
            {
                Success = false,
                Errors = new List<string> {"Workout not found"}
            };
        }

        if (String.IsNullOrEmpty(request.Comment))
        {
            return new OperationSingleResult<WorkoutUserComments>
            {
                Success = false,
                Errors = new List<string> { "Comment is empty" }
            };
        }
        
        var workoutUserComment = new WorkoutUserComments
        {
            WorkoutId = request.WorkoutId,
            CreatedAt = DateTime.UtcNow,
            User = user,
            Comment = request.Comment
        };
        
        _repository.WorkoutUserComment.CreateWorkoutUserCommentAsync(workoutUserComment, trackChanges: false);
        
        if (!workoutUserComment.Id.Equals(Guid.Empty))
        {
            // Update Workout Likes
            workout.Comments += 1;
        }

        await _repository.SaveAsync();

        return new OperationSingleResult<WorkoutUserComments>
        {
            Success = true,
            Item = workoutUserComment
        };
    }

    public async Task<OperationSingleResult<bool>> DeleteWorkoutUserComment(Guid id)
    {
        var workoutUserComment = await _repository.WorkoutUserComment.GetWorkoutUserCommentAsync(id, trackChanges: false);
    
        _repository.WorkoutUserComment.DeleteWorkoutUserComment(workoutUserComment, false);
        
        await _repository.SaveAsync();

        return new OperationSingleResult<bool>
        {
            Success = true
        };

    }

    public async Task<OperationListResult<WorkoutUserComments>> GetAllWorkoutUserCommentsByWorkoutIdAsync(Guid id)
    {
        var comments = await _repository.WorkoutUserComment.GetAllWorkoutUserCommentsByWorkoutIdAsync(id, false);

        return new OperationListResult<WorkoutUserComments>
        {
            Items = comments,
            Success = true
        };
    }

    public async Task<OperationListResult<WorkoutUserLikes>> GetAllWorkoutUserLikesAsync()
    {
        var userClaim = _httpContext.User;
        var res = _userManager.Users
            .FirstOrDefault(y => y.UserName.ToLower().Equals(userClaim.Identity.Name.ToLower()));
        var userId = Guid.Parse(res.Id);
        
        var likes = await _repository.WorkoutUserLikes.GetAllWorkoutUserLikesByUserIdAsync(userId, false);
        
        return new OperationListResult<WorkoutUserLikes>
        {
            Items = likes,
            Success = true
        };
    }

    public async Task<OperationSingleResult<bool>> DeleteWorkoutUserLike(Guid id)
    {
        var like = await _repository.WorkoutUserLikes.GetWorkoutUserLikeAsync(id, false);
        
        _repository.WorkoutUserLikes.DeleteWorkoutUserLike(like, false);
        
        await _repository.SaveAsync();
        
        return new OperationSingleResult<bool>
        {
            Success = true
        };
    }
}