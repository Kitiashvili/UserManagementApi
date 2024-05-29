using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Authentication;
using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication;

public sealed class JwtGenerator : IJwtGenerator
{
    private readonly JwtOptions _jwtOptions;
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IUserRolesService _userRolesService;
    public JwtGenerator(IOptions<JwtOptions> jwtOptions, 
        IUserRolesRepository userRolesRepository, 
        IUserRolesService userRolesService)
    {
        _userRolesRepository = userRolesRepository;
        _userRolesService = userRolesService;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<string> GenerateTokenAsync(UserEntity userEntity)
    {
        
        List<Claim> claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, userEntity.Username),
            new (ClaimTypes.Email, userEntity.Email),
            new ("Id", userEntity.Id.ToString()),
        };
        
        claims.AddRange(await _userRolesService.GetUserRolesAsync(userEntity.Id));
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.Now.AddHours(1),
            signingCredentials);
        
        string jwtTokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return jwtTokenValue;
    }
}