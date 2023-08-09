using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IWorkoutRepository> _workoutRepository;
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _workoutRepository = new Lazy<IWorkoutRepository>(
            () => new WorkoutRepository(_repositoryContext));
    }
    
    public IWorkoutRepository Workout => _workoutRepository.Value;
    
    public void Save() => _repositoryContext.SaveChanges();
    
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}