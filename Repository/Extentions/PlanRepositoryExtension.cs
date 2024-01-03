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
        
        if (!String.IsNullOrEmpty(request.PlanIds))
        {
            var planIdsList = request.PlanIds.Split(",");
            result = result.Where(x => planIdsList.Contains(x.Id.ToString()));
        }
        
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
            var searchTermList = request.SearchTerm.Split(",");
            foreach (var searchTerm in searchTermList)
            {
                result = result.FilterPlansBySearchTerm(searchTerm);
            }
        }

        return result;
    }
    
    private static IQueryable<Plan> FilterPlansBySearchTerm(this IQueryable<Plan> plan, string searchTerm)
    {
        var searchTermToLower = searchTerm.ToLower();

        return plan
            .Where(x => x.Name.ToLower().StartsWith(searchTermToLower)
                        || x.Description != null && x.Description.ToLower().Contains(searchTermToLower)
                        || x.Hashtags != null && x.Hashtags.ToLower().Contains(searchTermToLower));
    }
}