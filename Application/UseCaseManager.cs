using AutoMapper;
using EXOPEK_Backend.Application;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;

class UseCaseManager : IUseCaseManager
{
    
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    
    private Lazy<IWorkoutUseCase> _workoutUseCase;
    public UseCaseManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _workoutUseCase = new Lazy<IWorkoutUseCase>(
            () => new WorkoutUseCase(_repositoryManager));
    }
    
    public IWorkoutUseCase Workout => _workoutUseCase.Value;
}