using BookStoreAPI.API.CustomAttributes;
using BookStoreAPI.Application.DTOs.UserDTOs;
using BookStoreAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.API.Controllers
{
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Login(Login = "loginUserDto")]//custom attribute
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
            => CreateActionResult(await _userService.LoginAsync(loginUserDto));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SetUserDto setUserDto)
            => CreateActionResult(await _userService.AddUserAsync(setUserDto));
    }
}
