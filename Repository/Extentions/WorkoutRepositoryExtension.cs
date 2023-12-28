using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Repository.Extentions;

public static class WorkoutRepositoryExtension
{
    public static IQueryable<Workout> FilterWorkouts(this IQueryable<Workout> workout, WorkoutsRequest request)
    {
        var result = workout;
        
        if (!request.CategoryType.Equals(CategoryType.None))
        {
            result = result.Where(x => x.Category == request.CategoryType);
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
                result = result.FilterWorkoutsBySearchTerm(searchTerm);
            }
        }

        return result;
    }
    
    private static IQueryable<Workout> FilterWorkoutsBySearchTerm(this IQueryable<Workout> workout, string searchTerm)
    {
        var searchTermToLower = searchTerm.ToLower();

        return workout
            .Where(x => x.Name.ToLower().StartsWith(searchTermToLower)
                        || x.Description != null && x.Description.ToLower().Contains(searchTermToLower)
                        || x.Hashtags != null && x.Hashtags.ToLower().Contains(searchTermToLower));
    }
}