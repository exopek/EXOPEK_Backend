using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Application.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap <Workout, WorkoutsResponse>();
        CreateMap<Exercise, ExerciseResponse>();
        CreateMap<Plan, PlanResponse>();
        CreateMap<WorkoutUserComments, WorkoutUserCommentsResponse>();
        CreateMap<WorkoutUserLikes, WorkoutUserLikesResponse>();
        CreateMap<WorkoutUserCompletes, WorkoutUserCompletesResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<PlanUserStatus, PlanUserStatusResponse>()
            .ForMember(dest =>
                dest.WorkoutIds, opt =>
                opt.MapFrom(src => src.WorkoutIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)));
        CreateMap<Plan, PlanSingleResponse>()
            .ForMember(dest =>
                dest.Workouts, opt =>
                opt.MapFrom(src => src.PlanWorkouts));
        CreateMap<Workout, WorkoutSingleResponse>()
            .ForMember(dest =>
                dest.Exercises, opt =>
                opt.MapFrom(src => src.WorkoutExercises));
        CreateMap<Workout, WorkoutLikeSingleResponse>()
            .ForMember(dest =>
                dest.Exercises, opt =>
                opt.MapFrom(src => src.WorkoutExercises));
        CreateMap<WorkoutExercise ,ExerciseResponse>()
            .ForMember(dest =>
                dest.Id , opt =>
                    opt.MapFrom(src => src.Exercise.Id))
            .ForMember(dest =>
                dest.Name , opt =>
                opt.MapFrom(src => src.Exercise.Name))
            .ForMember(dest =>
                dest.StageType , opt =>
                opt.MapFrom(src => src.StageType))
            .ForMember(dest =>
                dest.VideoUrl , opt =>
                opt.MapFrom(src => src.Exercise.VideoUrl))
            .ForMember(dest =>
                dest.Category , opt =>
                opt.MapFrom(src => src.Exercise.Category))
            .ForMember(dest =>
                dest.Description , opt =>
                opt.MapFrom(src => src.Exercise.Description))
            .ForMember(dest =>
                dest.PreviewImageUrl , opt =>
                opt.MapFrom(src => src.Exercise.PreviewImageUrl))
            .ForMember(dest =>
                dest.StageRound , opt =>
                opt.MapFrom(src => src.StageRound))
            .ForMember(dest =>
                dest.StageOrder , opt =>
                opt.MapFrom(src => src.StageOrder))
            .ForMember(dest =>
                dest.Duration , opt =>
                opt.MapFrom(src => src.Duration))
            .ForMember(dest =>
                dest.Reps , opt =>
                opt.MapFrom(src => src.Reps))
            .ForMember(dest =>
                dest.Difficulty , opt =>
                opt.MapFrom(src => src.Exercise.Difficulty))
            ;
        CreateMap<PlanWorkout ,WorkoutsResponse>()
            .ForMember(dest =>
                dest.Id , opt =>
                opt.MapFrom(src => src.Workout.Id))
            .ForMember(dest =>
                dest.Name , opt =>
                opt.MapFrom(src => src.Workout.Name))
            .ForMember(dest =>
                dest.PhaseType , opt =>
                opt.MapFrom(src => src.PhaseType))
            .ForMember(dest =>
                dest.PreviewImageUrl , opt =>
                opt.MapFrom(src => src.Workout.PreviewImageUrl))
            ;

        CreateMap<UserRegisterRequest, User>();
    }

}