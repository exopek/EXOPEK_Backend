using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Contracts.Repository;

public interface IPlanUserStatusRepository
{
    public void CreatePlanUserStatus(PlanUserStatus planUserStatus, bool trackChanges);
    
    public Task<PlanUserStatus> GetPlanUserStatusAsync(Guid id, bool trackChanges);
    
    public Task<IEnumerable<PlanUserStatus>> GetAllPlanUserStatusesAsync(bool trackChanges);
    
    public void UpdatePlanUserStatus(PlanUserStatus planUserStatus, bool trackChanges);
}