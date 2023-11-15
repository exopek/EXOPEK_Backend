using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Repository.Extentions;

public static class PlanRepositoryExtension
{
    // Filter
    public static IQueryable<Plan> FilterPlans(this IQueryable<Plan> plan, PlansRequest request)
    {
        var result = plan;
        
        if (!request.TargetType.Equals(TargetType.None))
        {
            result = result.Where(x => x.Target == request.TargetType);
        }
        
        if (!request.DifficultyType.Equals(DifficultyType.None))
        {
            result = result.Where(x => x.Difficulty == request.DifficultyType);
        }

        if (!String.IsNullOrEmpty(request.SearchTerm))
        {
            var searchTermToLower = request.SearchTerm.ToLower();

            result = result
                .Where(x => x.Name.ToLower().StartsWith(searchTermToLower)
                            || x.Description != null && x.Description.ToLower().Contains(searchTermToLower)
                            || x.Hashtags != null && x.Hashtags.ToLower().Contains(searchTermToLower));
        }

        return result;
    }
}