using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;

namespace EXOPEK_Backend.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IWorkoutRepository> _workoutRepository;
    private readonly Lazy<IWorkoutUserCompletesRepository> _workoutUserCompletesRepository;
    private readonly Lazy<IWorkoutUserLikesRepository> _workoutUserLikesRepository;
    private readonly Lazy<IPlanRepository> _planRepository;
    private readonly Lazy<IPlanUserStatusRepository> _planUserStatusRepository;
    private readonly Lazy<IWorkoutUserCommentRepository> _workoutUserCommentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _workoutRepository = new Lazy<IWorkoutRepository>(
            () => new WorkoutRepository(_repositoryContext));
        _workoutUserCompletesRepository = new Lazy<IWorkoutUserCompletesRepository>(
            () => new WorkoutUserCompletesRepository(_repositoryContext));
        _workoutUserLikesRepository = new Lazy<IWorkoutUserLikesRepository>(
            () => new WorkoutUserLikesRepository(_repositoryContext));
        _planRepository = new Lazy<IPlanRepository>(
            () => new PlanRepository(_repositoryContext));
        _planUserStatusRepository = new Lazy<IPlanUserStatusRepository>(
            () => new PlanUserStatusRepository(_repositoryContext));
        _workoutUserCommentRepository = new Lazy<IWorkoutUserCommentRepository>(
            () => new WorkoutUserCommentRepository(_repositoryContext));
    }

    public IWorkoutRepository Workout => _workoutRepository.Value;

    public IWorkoutUserCompletesRepository WorkoutUserCompletes => _workoutUserCompletesRepository.Value;

    public IWorkoutUserLikesRepository WorkoutUserLikes => _workoutUserLikesRepository.Value;

    public IPlanRepository Plan => _planRepository.Value;

    public IPlanUserStatusRepository PlanUserStatus => _planUserStatusRepository.Value;

    public IWorkoutUserCommentRepository WorkoutUserComment => _workoutUserCommentRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}