namespace EXOPEK_Backend.Contracts.Repository;

public interface IRepositoryManager
{
    IWorkoutRepository Workout { get; }
    IWorkoutUserCompletesRepository WorkoutUserCompletes { get; }
    
    IWorkoutUserLikesRepository WorkoutUserLikes { get; }
    
    IPlanRepository Plan { get; }
    void Save();
    Task SaveAsync();
}