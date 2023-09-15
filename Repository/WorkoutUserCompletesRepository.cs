using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Repository;

public class WorkoutUserCompletesRepository : RepositoryBase<WorkoutUserCompletes>, IWorkoutUserCompletesRepository 
{
    public WorkoutUserCompletesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public OperationSingleResult<WorkoutUserCompletes> CreateWorkoutUserCompletes(WorkoutUserCompletes workoutUserCompletes, bool trackChanges)
    {
        Create(workoutUserCompletes);
        return new OperationSingleResult<WorkoutUserCompletes>
        {
            Success = true,
            Item = workoutUserCompletes
        };
    }
}