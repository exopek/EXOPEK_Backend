using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Repository;

public class WorkoutUserLikesRepository : RepositoryBase<WorkoutUserLikes>, IWorkoutUserLikesRepository
{
    public WorkoutUserLikesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public OperationSingleResult<WorkoutUserLikes> CreateWorkoutUserLike(WorkoutUserLikes workoutUserLike, bool trackChanges)
    {
        Create(workoutUserLike);
        return new OperationSingleResult<WorkoutUserLikes>
        {
            Success = true,
            Item = workoutUserLike
        };
    }
}