using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Repository.Extentions;

public static class PlanRepositoryExtension
{
    // Filter
    public static IQueryable<Plan> FilterPlans(this IQueryable<Plan> plans, string name, string description, string difficulty, string type)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return plans;
        }

        return plans.Where(p => p.Name.ToLower().Contains(name.Trim().ToLower()));
    }
}