using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IWorkoutRepository> _workoutRepository;
    private readonly Lazy<IWorkoutUserCompletesRepository> _workoutUserCompletesRepository;
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _workoutRepository = new Lazy<IWorkoutRepository>(
            () => new WorkoutRepository(_repositoryContext));
        _workoutUserCompletesRepository = new Lazy<IWorkoutUserCompletesRepository>(
            () => new WorkoutUserCompletesRepository(_repositoryContext));
    }
    
    public IWorkoutRepository Workout => _workoutRepository.Value;
    
    public IWorkoutUserCompletesRepository WorkoutUserCompletes => _workoutUserCompletesRepository.Value;
    
    public void Save() => _repositoryContext.SaveChanges();
    
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}