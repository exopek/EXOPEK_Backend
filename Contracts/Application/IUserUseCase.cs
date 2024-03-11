using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Contracts.Application;

public interface IUserUseCase
{
    Task<IdentityResult> CreateUserAsync(UserRegisterRequest userForRegistration);
    Task<OperationSingleResult<User>> ValidateUserAsync(UserAuthenticationRequest userAuthenticationRequest);
    Task<OperationSingleResult<string>> GenerateJwtTokenAsync();
    
    Task<OperationResult> LogoutAsync();
    
    Task<OperationResult> UpdateUserAsync(User user);
    
    Task<OperationSingleResult<User>> GetUserAsync();
}