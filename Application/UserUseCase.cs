using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EXOPEK_Backend.Application;

public class UserUseCase : IUserUseCase
{
    private readonly UserManager<User> _userManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    private User _user;
    
    public UserUseCase(ILoggerManager logger, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
    {
        _logger = logger;
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
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
    
    public async Task<OperationSingleResult<User>> ValidateUserAsync(UserAuthenticationRequest userAuthenticationRequest)
    {
        _user = await _userManager.FindByNameAsync(userAuthenticationRequest.UserName);
        
        if (_user is null)
        {
            _logger.LogInfo($"User with username: {userAuthenticationRequest.UserName} does not exist in the database.");
            return new OperationSingleResult<User>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }

        var result = await _userManager.CheckPasswordAsync(_user, userAuthenticationRequest.Password);
        
        if (result is not true)
        {
            _logger.LogInfo($"User with username: {userAuthenticationRequest.UserName} entered wrong password or username.");
            return new OperationSingleResult<User>
            {
                Success = false,
                Errors = new List<string> {"Wrong password or username"}
            };
        }

        return new OperationSingleResult<User>
        {
            Item = _user,
            Success = true
        };
    }
    
    public async Task<OperationSingleResult<string>> GenerateJwtTokenAsync()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        if (token.IsNullOrEmpty())
        {
            _logger.LogInfo($"Token generation failed");
            return new OperationSingleResult<string>
            {
                Success = false,
                Errors = new List<string> { "Token generation failed" },
            };
        }

        return new OperationSingleResult<string>
        {
            Item = token,
            Success = true
        };

    }
    
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:accessTokenSecret"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }
    
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, 
        List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken
        (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["AccessTokenLifetime"])),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }

    
    
   
}