using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Application;
using Microsoft.AspNetCore.Mvc;

namespace EXOPEK_Backend.Controllers;

[ApiController]
[Route("api/users")]

public class UserController : ControllerBase
{
    private readonly IUseCaseManager _useCaseManager;
    private readonly IMapper _mapper;
    
    public UserController(IUseCaseManager useCaseManager, IMapper mapper)
    {
        _useCaseManager = useCaseManager;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    
    public async Task<IActionResult> RegisterUser(
        [FromBody] UserRegisterRequest userRegisterRequest)
    {
        var result = await _useCaseManager.User.CreateUserAsync(userRegisterRequest);
        
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        
        //var userDto = _mapper.Map<UserResponse>(result.Item);
        
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest 
        user)
    {
        
        var userResult = await _useCaseManager.User.ValidateUserAsync(user);
        if (!userResult.Success)
            return Unauthorized();
        var token = await _useCaseManager.User.GenerateJwtTokenAsync();

        if (!token.Success)
            return Unauthorized();
        
        return Ok(new { Token = token.Item });
    }
    
}