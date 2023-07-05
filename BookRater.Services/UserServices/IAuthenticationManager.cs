using BookRater.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookRater.Services.UserServices
{
    public interface IAuthenticationManager
    {
        Task<IEnumerable<IdentityError>> Register(UserEntity userEntity);
    }
}