namespace EXOPEK_Backend.Contracts.Repository;

public interface IRepositoryManager
{
    IWorkoutRepository Workout { get; }
    void Save();
    Task SaveAsync();
}