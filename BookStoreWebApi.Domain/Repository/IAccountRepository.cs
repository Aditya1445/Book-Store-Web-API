using BookStoreWebApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUp user);

        Task<string> LoginUser(Login user);

        Task SignOut();
    }
}
