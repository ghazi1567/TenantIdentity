using TenantIdentity.Application.Abstractions.Interfaces.Identity;
using TenantIdentity.Application.DTOs;
using TenantIdentity.Domain.Interfaces;
using eBuildingBlocks.Application.Features;

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
            var result = new ResponseModel<LoginResponseDto>();
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
                return result.AddErrorMessage("User not found");

            if (!user.EmailConfirmed)
                return result.AddErrorMessage("Email not confirmed");

            var isPasswordValid = await _userRepository.CheckPasswordSignInAsync(user, password);
            if (!isPasswordValid)
                return result.AddErrorMessage("Invalid credentials");



            var claims = await _claimsProvider.GetClaimsAsync(user);
            var token = _tokenService.GenerateToken(user, claims);

            result.AddSuccessMessage("Authentication successful");
            result.Data = new LoginResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            return result;
        }

        public Task<ResponseModel<LoginResponseDto>> AuthenticateGoogleAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
