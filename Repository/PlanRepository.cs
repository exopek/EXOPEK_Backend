using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EXOPEK_Backend.Repository;

public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
{
    public PlanRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<Plan>> GetAllPlansAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(p => p.Name).ToListAsync();

    public async Task<Plan> GetPlanAsync(Guid id, Guid? planStatusId, bool trackChanges)
    {
        var query = FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(p => p.PlanWorkouts)
            .ThenInclude(pw => pw.Workout);

        if (planStatusId.HasValue)
        {
            var query1 = FilterPlanUserStatus(query, planStatusId.Value);
            return await query1.SingleOrDefaultAsync();
        }

        return await query.SingleOrDefaultAsync();
    }
    private IQueryable<Plan> FilterPlanUserStatus(IQueryable<Plan> query, Guid planStatusId)
    {
        return query
            .Include(pu => pu.PlanUserStatus)
            .Where(pu => pu.PlanUserStatus.Any(pus => pus.Id.Equals(planStatusId)));
    } 
}