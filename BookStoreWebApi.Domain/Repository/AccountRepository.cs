using BookStoreWebApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _configuration = configuration;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUp user)
        {
            var newUser = new ApplicationUser()
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                Email = user.email,
                UserName = user.email
            };
            return await _userManager.CreateAsync(newUser, user.password);
        }

        public async Task<string> LoginUser(Login user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.email, user.password, false, false);
            if (!result.Succeeded)
            {
                return null!;
            }
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.email)
            //    }),
            //    Expires = DateTime.UtcNow.AddHours(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
