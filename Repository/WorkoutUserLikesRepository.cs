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
    
    public void CreateWorkoutUserLike(WorkoutUserLikes workoutUserLike, bool trackChanges)
    {
        Create(workoutUserLike);
    }
}