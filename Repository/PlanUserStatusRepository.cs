using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using EXOPEK_Backend.Repository.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EXOPEK_Backend.Repository;

public class PlanUserStatusRepository : RepositoryBase<PlanUserStatus>, IPlanUserStatusRepository
{
    public PlanUserStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public void CreatePlanUserStatus(PlanUserStatus planUserStatus, bool trackChanges)
    {
        Create(planUserStatus);
    }
    
    public async Task<PlanUserStatus> GetPlanUserStatusAsync(Guid id, bool trackChanges) =>
        await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    
    public async Task<IEnumerable<PlanUserStatus>> GetAllPlanUserStatusesAsync(PlanStatusRequest request, bool trackChanges) =>
        await FindAll(trackChanges)
            .FilterPlanUserStatuses(request)
            .ToListAsync();
    
    public void UpdatePlanUserStatus(PlanUserStatus planUserStatus, bool trackChanges) =>
        Update(planUserStatus);
}