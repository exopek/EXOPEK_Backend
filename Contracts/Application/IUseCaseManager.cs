namespace EXOPEK_Backend.Contracts.Application;

public interface IUseCaseManager
{
    IWorkoutUseCase Workout { get; }
}