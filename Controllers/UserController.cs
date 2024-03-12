using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        var user = await _useCaseManager.User.GetUserAsync();
        if (!user.Success)
            return BadRequest(user.Errors);
        var userDto = _mapper.Map<UserResponse>(user.Item);
        return Ok(userDto);
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
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _useCaseManager.User.LogoutAsync();
        if (!result.Success)
            return BadRequest(result.Errors);
        return Ok();
    }
    

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUser(
        [FromBody] UserUpdateDto userUpdateDto)
    {
        var user = _mapper.Map<User>(userUpdateDto);
        var result = await _useCaseManager.User.UpdateUserAsync(user);
        if (!result.Success)
            return BadRequest(result.Errors);
        return Ok(result);
    }
    
}