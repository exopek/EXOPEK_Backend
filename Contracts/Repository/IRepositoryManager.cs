namespace EXOPEK_Backend.Contracts.Repository;

public interface IRepositoryManager
{
    IWorkoutRepository Workout { get; }
    IWorkoutUserCompletesRepository WorkoutUserCompletes { get; }
    
    IWorkoutUserLikesRepository WorkoutUserLikes { get; }
    
    IPlanRepository Plan { get; }
    
    IPlanUserStatusRepository PlanUserStatus { get; }
    
    IWorkoutUserCommentRepository WorkoutUserComment { get; }
    void Save();
    Task SaveAsync();
}