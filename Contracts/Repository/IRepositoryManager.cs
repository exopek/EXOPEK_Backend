namespace EXOPEK_Backend.Contracts.Repository;

public interface IRepositoryManager
{
    IWorkoutRepository Workout { get; }
    IWorkoutUserCompletesRepository WorkoutUserCompletes { get; }
    void Save();
    Task SaveAsync();
}