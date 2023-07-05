using AutoMapper;
using BookRater.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BookRater.Services.UserServices
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public AuthenticationManager(IConfiguration configuration, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
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