using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;

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

    public void DeleteWorkoutUserLike(WorkoutUserLikes workoutUserLike, bool trackChanges)
    {
        Delete(workoutUserLike);
    }

    public async Task<WorkoutUserLikes> GetWorkoutUserLikeAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    

    public async Task<IEnumerable<WorkoutUserLikes>> GetAllWorkoutUserLikesByUserIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.User.Id.Equals(id.ToString()), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .Include(c => c.Workout)
            .ToListAsync();
    
}