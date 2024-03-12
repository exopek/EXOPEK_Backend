using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EXOPEK_Backend.Application.Dtos.Requests;
using EXOPEK_Backend.Application.Dtos.Responses;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Entities.Application;
using EXOPEK_Backend.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EXOPEK_Backend.Application;

public class UserUseCase : IUserUseCase
{
    private readonly UserManager<User> _userManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly HttpContext _httpContext;

    private User _user;
    
    public UserUseCase(
        ILoggerManager logger,
        UserManager<User> userManager,
        IMapper mapper,
        IConfiguration configuration,
        IOptions<JwtSettings> jwtSettings,
        IHttpContextAccessor httpContext)
    {
        _logger = logger;
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
        _jwtSettings = jwtSettings;
        _httpContext = httpContext.HttpContext;
    }

    public async Task<IdentityResult> CreateUserAsync(UserRegisterRequest userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);
        user.ImageUrl = "https://www.gravatar.com/avatar";
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
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim("id", _user.Id.ToString()),
            new Claim(ClaimTypes.Email, _user.Email),
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
    
    public async Task<OperationSingleResult<UserRegistrationResult>> LoginAsyncNew(
            User user,
            string password,
            string googleIdToken,
            string appleIdToken,
            string[] roles
        )
        {
            if (user == null)
            {
                var errorMessage = $"Given Argument is null {nameof(user)}";
                return new OperationSingleResult<UserRegistrationResult>
                {
                    Errors = new[] { errorMessage }
                };
            }

            if (/*user.AuthType.Equals(UserAuthType.DEFAULT) && */string.IsNullOrWhiteSpace(password))
            {
                var errorMessage = $"Given Argument is null or empty {nameof(password)}";
                return new OperationSingleResult<UserRegistrationResult>
                {
                    Errors = new[] { errorMessage }
                };
            }

            /*var isInAllExpectedRoles = false;

            foreach (var item in roles)
            {
                isInAllExpectedRoles = await _userManager.IsInRoleAsync(user, item);
            }

            if (!isInAllExpectedRoles)
            {
                var errorMessage =
                    $"User with id {user.Id} is missing one or more expected roles {string.Join(", ", roles)}";
                return new OperationSingleResult<UserRegistrationResult>
                {
                    Errors = new[] { errorMessage }
                };
            }*/

            /*if (user.AuthType.Equals(UserAuthType.GOOGLE))
            {
                if (string.IsNullOrWhiteSpace(googleIdToken))
                {
                    var errorMessage = $"Given Argument is null or empty {nameof(googleIdToken)}";
                    return new OperationSingleResult<UserRegistrationResult>
                    {
                        Errors = new[] { errorMessage }
                    };
                }

                var res = await _httpClientService.ValidateGoogleIdTokenAsync(googleIdToken);

                if (!res.Success)
                {
                    var errorMessage = $"Given Argument is invalid {nameof(googleIdToken)}";
                    return new OperationSingleResult<UserRegistrationResult>
                    {
                        Errors = new[] { errorMessage }
                    };
                }
            }

            if (user.AuthType.Equals(UserAuthType.APPLE))
            {
                if (string.IsNullOrWhiteSpace(appleIdToken))
                {
                    var errorMessage = $"Given Argument is null or empty {nameof(appleIdToken)}";
                    return new OperationSingleResult<UserRegistrationResult>
                    {
                        Errors = new[] { errorMessage }
                    };
                }

                var res = await _httpClientService.ValidateAppleIdTokenAsync(appleIdToken);

                if (!res.Success)
                {
                    var errorMessage = $"Given Argument is invalid {nameof(appleIdToken)}";
                    return new OperationSingleResult<UserRegistrationResult>
                    {
                        Errors = new[] { errorMessage }
                    };
                }
            }*/

            /*if (user.AuthType.Equals(UserAuthType.DEFAULT))
            {*/
                var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);


                if (!userHasValidPassword)
                    return new OperationSingleResult<UserRegistrationResult>
                    {
                        Errors = new[] { "Password is wrong" }
                    };
            /*}*/

            
            /*}*/

            var tokenResult = await GetUserLoginResultWithTokenAsync(user);

            if (!tokenResult.Success)
            {
                var errorMessage = $"Given Argument is invalid {nameof(tokenResult)}";
                return new OperationSingleResult<UserRegistrationResult>
                {
                    Errors = new[] { errorMessage }
                };
            }

            return new OperationSingleResult<UserRegistrationResult>
            {
                Success = true,
                Item = new UserRegistrationResult
                {
                    User = _mapper.Map<UserResponse>(user),
                    Token = tokenResult.Item
                }
            };
        }
    
    private async Task<OperationSingleResult<string>> GetUserLoginResultWithTokenAsync(
        User user
    )
    {
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email),
            /*new Claim("authType", user.AuthType.ToString())*/
            // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // token id needed for refresh token
        };

        var roles = await _userManager.GetRolesAsync(user);

        foreach (var role in roles)
            claims.Add(new Claim("roles", role.ToLowerInvariant()));

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Value.AccessTokenSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_jwtSettings.Value.AccessTokenLifetime),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new OperationSingleResult<string>
        {
            Success = true,
            Item = tokenHandler.WriteToken(token),
        };
    }
    
    public Task<OperationResult> LogoutAsync()
    {
        var userId = _httpContext.User.FindAll(x => x.Type == "id").FirstOrDefault()?.Value;

        if (userId == null)
            return Task.FromResult(
                new OperationResult { Errors = new[] { "Something went wrong" } }
            );

        // await _repository.RefreshToken.RemoveAllByUserIdAsync(userId);
        // await _repository.SaveAsync();

        return Task.FromResult(new OperationResult { Success = true });
    }

    public async Task<OperationResult> UpdateUserAsync(User userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
        if (user == null)
        {
            return new OperationResult
            {
                Success = false,
                Errors = new[] { "User not found" }
            };
        }
        user.ImageUrl = userDto.ImageUrl;
        user.UserName = userDto.UserName;
        user.Email = userDto.Email;
        user.PhoneNumber = userDto.PhoneNumber;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Age = userDto.Age;
        user.Height = userDto.Height;
        user.Weight = userDto.Weight;
        user.PreviousTrainingFrequency = userDto.PreviousTrainingFrequency;
        user.TrainingFrequency = userDto.TrainingFrequency;
        user.SportType = userDto.SportType;
        
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return new OperationResult
            {
                Success = false,
                Errors = result.Errors.Select(x => x.Description).ToArray()
            };
        }
        return new OperationResult
        {
            Success = true
        };
    }

    public async Task<OperationSingleResult<User>> GetUserAsync()
    {
        var userClaim = _httpContext.User;
        var userName = userClaim.Identity.Name;
        var res = _userManager.Users
            .FirstOrDefault(y => y.UserName.ToLower().Equals(userClaim.Identity.Name.ToLower()));
        if (res == null)
        {
            return new OperationSingleResult<User>
            {
                Success = false,
                Errors = new List<string> {"User not found"}
            };
        }
        
        return new OperationSingleResult<User>
        {
            Item = res,
            Success = true
        };
    }
}