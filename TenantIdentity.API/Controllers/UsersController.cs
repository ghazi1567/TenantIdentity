using TenantIdentity.Application.Abstractions.Interfaces.Identity;
using TenantIdentity.Application.DTOs;
using eBuildingBlocks.API.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TenantIdentity.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET api/<UsersController>/5
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return ApiResult(await _userService.GetUserByEmailAsync(email));
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            return ApiResult(await _userService.GetUserByIdAsync(userId));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterDto model)
        {
            return ApiResult(await _userService.RegisterAsync(model));
        }


    }
}
