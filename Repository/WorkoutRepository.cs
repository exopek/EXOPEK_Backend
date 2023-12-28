using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using EXOPEK_Backend.Repository.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Repository;

public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
{
    public WorkoutRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync(WorkoutsRequest request, bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .FilterWorkouts(request)
            .ToListAsync();
    
    public async Task<Workout> GetWorkoutAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(c => c.WorkoutUserComments)
            .Include(c => c.WorkoutUserLikes)
            .Include(c => c.WorkoutUserCompletes)
            .Include(w => w.WorkoutExercises)
            .ThenInclude(e => e.Exercise)
            .SingleOrDefaultAsync();
}