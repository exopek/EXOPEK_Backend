using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Entities.Models;

namespace EXOPEK_Backend.Application.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap <Workout, WorkoutsResponse>();
    }

}