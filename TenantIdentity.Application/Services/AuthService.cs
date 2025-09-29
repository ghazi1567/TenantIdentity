using eBuildingBlocks.Application.Features;
using TenantIdentity.Application.Abstractions.Interfaces.Identity;
using TenantIdentity.Application.DTOs;
using TenantIdentity.Domain.Interfaces;

namespace TenantIdentity.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClaimsProvider _claimsProvider;
        private readonly ITokenService _tokenService;
        public AuthService(IUserRepository userRepository, IClaimsProvider claimsProvider, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _claimsProvider = claimsProvider;
            _tokenService = tokenService;
        }
        public async Task<ResponseModel<LoginResponseDto>> AuthenticateAsync(string email, string password)
        {

            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
                return ResponseModel<LoginResponseDto>.Fail("User not found");

            if (!user.EmailConfirmed)
                return ResponseModel<LoginResponseDto>.Fail("Email not confirmed");

            var isPasswordValid = await _userRepository.CheckPasswordSignInAsync(user, password);
            if (!isPasswordValid)
                return ResponseModel<LoginResponseDto>.Fail("Invalid credentials");



            var claims = await _claimsProvider.GetClaimsAsync(user);
            var token = _tokenService.GenerateToken(user, claims);


            var response = new LoginResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            return ResponseModel<LoginResponseDto>.Ok(response, "Authentication successful"); ;
        }

        public Task<ResponseModel<LoginResponseDto>> AuthenticateGoogleAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
