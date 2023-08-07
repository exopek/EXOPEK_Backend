using System.Net.Mime;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Repository;

public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
{
    public WorkoutRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .Include(w => w.Images)
            .Include(w => w.Videos)
            .OrderBy(c => c.Name)
            .ToListAsync();
}