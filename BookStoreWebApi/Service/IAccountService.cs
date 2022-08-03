using BookStoreWebApi.DTO;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApi.Service
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(SignUpModelDTO user);

        Task<string> LoginUser(LoginModelDTO user);

        Task SignOut();
    }
}
