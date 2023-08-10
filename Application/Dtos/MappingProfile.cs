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
        CreateMap <Workout, WorkoutSingleResponse>()
            .ForMember(dest => 
                dest.Exercises, opt =>
                opt.MapFrom(src => src.WorkoutExercises.Select(we => we.Exercise)));
        CreateMap<UserRegisterRequest, User>();
    }

}