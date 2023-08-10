using EXOPEK_Backend.Application.Dtos.Requests;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Contracts.Application;

public interface IUserUseCase
{
    Task<IdentityResult> CreateUserAsync(UserRegisterRequest userForRegistration);
}