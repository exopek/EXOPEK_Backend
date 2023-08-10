using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace EXOPEK_Backend.Application;

public class UserUseCase : IUserUseCase
{
    private readonly UserManager<User> _userManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    
    public UserUseCase(ILoggerManager logger, UserManager<User> userManager, IMapper mapper)
    {
        _logger = logger;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IdentityResult> CreateUserAsync(UserRegisterRequest userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);
        var result = await _userManager.CreateAsync(user, 
            userForRegistration.Password);
        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

        return result;

    }
    
    
   
}