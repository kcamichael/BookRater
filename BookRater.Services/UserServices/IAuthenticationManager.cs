using BookRater.Data.Entities;
using BookRater.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace BookRater.Services.UserServices
{
    public interface IAuthenticationManager
    {
        Task<IEnumerable<IdentityError>> Register(UserEntity userEntity);

        Task<AuthResponse> Login(Login login);
    }
}