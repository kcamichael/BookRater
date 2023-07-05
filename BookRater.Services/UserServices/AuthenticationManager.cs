using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BookRater.Data.Entities;
using BookRater.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookRater.Services.UserServices
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private string USERNAME = "";

        public AuthenticationManager(IConfiguration configuration, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AuthResponse> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            bool isValidUser = await _userManager.CheckPasswordAsync(user!, login.Password);

            if (user is null || isValidUser == false)
            {
                return new AuthResponse();
            }

            var token = await GenerateToken(user);

            return new AuthResponse
            {
                UserName = user.Email!,
                Token = token
            };
        }

        private async Task<string> GenerateToken(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim("name", $"{user.FullName}"),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uID", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            USERNAME = claims.FirstOrDefault(x => x.Type == "name")!.Value;

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(14),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IEnumerable<IdentityError>> Register(UserEntity userEntity)
        {
            var user = _mapper.Map<UserEntity>(userEntity);

            user.UserName = userEntity.Email;
            user.DateCreated = DateTime.UtcNow;

            var result = await _userManager.CreateAsync(user, userEntity.PasswordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
    }
}