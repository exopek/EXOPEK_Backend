using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Repository;

public class WorkoutUserCommentRepository : RepositoryBase<WorkoutUserComments>, IWorkoutUserCommentRepository
{
    public WorkoutUserCommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public OperationSingleResult<WorkoutUserComments> CreateWorkoutUserCommentAsync(WorkoutUserComments workoutUserComment, bool trackChanges)
    {
        Create(workoutUserComment);
        return new OperationSingleResult<WorkoutUserComments>
        {
            Success = true,
            Item = workoutUserComment
        };
    }
    
    public async Task<IEnumerable<WorkoutUserComments>> GetAllWorkoutUserCommentsByIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.WorkoutId.Equals(id), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();
    
    
}