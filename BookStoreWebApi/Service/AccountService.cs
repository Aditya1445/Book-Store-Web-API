using AutoMapper;
using BookStoreWebApi.Domain.Models;
using BookStoreWebApi.Domain.Repository;
using BookStoreWebApi.DTO;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApi.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpModelDTO user)
        {
            var mappedUser = _mapper.Map<SignUp>(user);
            if(mappedUser == null)
            {
                throw new Exception("Entity could not be mapped");
            }
            return await _accountRepo.CreateUserAsync(mappedUser);
            
        }

        public async Task<string> LoginUser(LoginModelDTO user)
        {
            var mapped = _mapper.Map<Login>(user);
            if (mapped == null)
            {
                throw new Exception("Entity could not be mapped");
            }
            var res = await _accountRepo.LoginUser(mapped);
            if (string.IsNullOrEmpty(res))
            {
                return UnauthorizedAccessException();
            }
            return res;
        }

        private string UnauthorizedAccessException()
        {
            throw new Exception("Access denied");
        }

        public Task SignOut()
        {
            return _accountRepo.SignOut();
        }
    }
}
