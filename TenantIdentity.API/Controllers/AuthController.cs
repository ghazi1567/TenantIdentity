using TenantIdentity.Application.Abstractions.Interfaces.Identity;
using TenantIdentity.Application.DTOs;
using eBuildingBlocks.API.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TenantIdentity.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
            => ApiResult(await _authService.AuthenticateAsync(dto.Email, dto.Password));


        //[HttpPost("external-google")]
        //public async Task<IActionResult> Google([FromBody] GoogleAuthRequest request)
        //{
        //    GoogleJsonWebSignature.Payload payload;
        //    try
        //    {
        //        payload = await _googleAuthService.ValidateAsync(request.IdToken);
        //    }
        //    catch
        //    {
        //        return BadRequest(new { Error = "Invalid Google token" });
        //    }

        //    var result = await _authService.AuthenticateGoogleAsync(payload.Email);
        //    return ApiResult(result);
        //}


    }
}
