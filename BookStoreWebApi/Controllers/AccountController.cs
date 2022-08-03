using BookStoreWebApi.DTO;
using BookStoreWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _userService;
        public AccountController(IAccountService userService)
        {
            _userService = userService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> AddUser([FromBody] SignUpModelDTO userDTO)
        {
            var res = await _userService.CreateUserAsync(userDTO);
            if (res.Succeeded)
            {
                return Ok(res.Succeeded);
            }
            return Unauthorized();

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModelDTO loginuserDTO)
        {
            var res = await _userService.LoginUser(loginuserDTO);
            return Ok(res);

        }
    }

}
