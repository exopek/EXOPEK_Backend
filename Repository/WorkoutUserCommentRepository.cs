using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Repository;

public class WorkoutUserCommentRepository : RepositoryBase<WorkoutUserComments>, IWorkoutUserCommentRepository
{
    public WorkoutUserCommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public void CreateWorkoutUserCommentAsync(WorkoutUserComments workoutUserComment, bool trackChanges)
    {
        Create(workoutUserComment);
    }
    
    public async Task<IEnumerable<WorkoutUserComments>> GetAllWorkoutUserCommentsByWorkoutIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.WorkoutId.Equals(id), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .Include(c => c.User)
            .ToListAsync();

    public void DeleteWorkoutUserComment(WorkoutUserComments workoutUserComment, bool trackChanges)
    {
        Delete(workoutUserComment);
    }
    
    public async Task<WorkoutUserComments> GetWorkoutUserCommentAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(c => c.User)
            .SingleOrDefaultAsync();
}