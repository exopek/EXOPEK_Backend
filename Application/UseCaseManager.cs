using AutoMapper;
using EXOPEK_Backend.Application;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

class UseCaseManager : IUseCaseManager
{
    private Lazy<IWorkoutUseCase> _workoutUseCase;
    private Lazy<IUserUseCase> _userUseCase;
    private Lazy<IPlanUseCase> _planUseCase;
    public UseCaseManager(
        IRepositoryManager repositoryManager,
        ILoggerManager logger,
        IMapper mapper,
        UserManager<User> userManager,
        IConfiguration configuration,
        IOptions<JwtSettings> jwtSettings,
        IHttpContextAccessor httpContextAccessor
        )
    {
        _workoutUseCase = new Lazy<IWorkoutUseCase>(
            () => new WorkoutUseCase(repositoryManager, userManager, httpContextAccessor));
        _userUseCase = new Lazy<IUserUseCase>(
            () => new UserUseCase(logger, userManager, mapper, configuration, jwtSettings, httpContextAccessor));
        _planUseCase = new Lazy<IPlanUseCase>(
            () => new PlanUseCase(repositoryManager, userManager, httpContextAccessor));
    }
    
    public IWorkoutUseCase Workout => _workoutUseCase.Value;
    public IUserUseCase User => _userUseCase.Value;
    
    public IPlanUseCase Plan => _planUseCase.Value;
}