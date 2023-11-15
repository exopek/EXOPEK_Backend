using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Repository.Extentions;

public static class PlanUserStatusRepositoryExtension
{
    public static IQueryable<PlanUserStatus> FilterPlanUserStatuses(this IQueryable<PlanUserStatus> planUserStatuses,
        PlanStatusRequest request)
    {
        var result = planUserStatuses;


        result = result.Where(pus =>
            pus.User.Id.Equals(request.UserId.ToString()));

        if (request.PlanId != null)
        {
            result = result.Where(pus => pus.PlanId.Equals(request.PlanId));
        }

        if (request.Status != null)
        {
            result = result.Where(pus => pus.Status.Equals(request.Status));
        }


        return result;
    }
}