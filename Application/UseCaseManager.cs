using AutoMapper;
using EXOPEK_Backend.Application;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;

class UseCaseManager : IUseCaseManager
{
    
    /*private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly UserManager<User> _userManager;*/

    private Lazy<IWorkoutUseCase> _workoutUseCase;
    private Lazy<IUserUseCase> _userUseCase;
    public UseCaseManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
    {
        //_repositoryManager = repositoryManager;
        _workoutUseCase = new Lazy<IWorkoutUseCase>(
            () => new WorkoutUseCase(repositoryManager));
        _userUseCase = new Lazy<IUserUseCase>(
            () => new UserUseCase(logger, userManager, mapper));
    }
    
    public IWorkoutUseCase Workout => _workoutUseCase.Value;
    public IUserUseCase User => _userUseCase.Value;
}