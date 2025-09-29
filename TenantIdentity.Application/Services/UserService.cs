using TenantIdentity.Application.Abstractions.Interfaces.Identity;
using TenantIdentity.Application.DTOs;
using TenantIdentity.Domain.IdentityModels;
using TenantIdentity.Domain.Interfaces;
using eBuildingBlocks.Application.Features;
using System.Net;

namespace TenantIdentity.Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository { get; set; }
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<ResponseModel<List<UserDto>>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<UserDto>> GetUserByEmailAsync(string userEmail)
        {
            var result = await _userRepository.FindByEmailAsync(userEmail);
            if (result == null)
            {
                return new ResponseModel<UserDto>().AddErrorMessage("User Not found");
            }

            var userDto = new UserDto(result.Id, result.Email, result.EmailConfirmed, result.TenantId);

            return new ResponseModel<UserDto>().AddSuccessMessage(userDto, "User fetched successfully");
        }

        public async Task<ResponseModel<UserDto>> GetUserByIdAsync(string userId)
        {
            var result = await _userRepository.FindByIdAsync(userId);
            if (result == null)
            {
                return new ResponseModel<UserDto>().AddErrorMessage("User Not found");
            }

            var userDto = new UserDto(result.Id, result.Email, result.EmailConfirmed, result.TenantId);

            return new ResponseModel<UserDto>().AddSuccessMessage(userDto, "User fetched successfully");
        }

        public async Task<ResponseModel> RegisterAsync(RegisterDto dto)
        {
            var applicateionUser = new ApplicationUser(dto.Email, dto.UserName);
            var result = await _userRepository.CreateAsync(applicateionUser, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return new ResponseModel<UserDto>().AddErrorMessage(errors);
            }

            return new ResponseModel<UserDto>().AddSuccessMessage("User registered successfully");
        }

        public async Task<ResponseModel> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var result = new ResponseModel();
            if (!Guid.TryParse(dto.UserId, out var id))
                return result.AddErrorMessage("Invalid userId");

            var user = await _userRepository.FindByIdAsync(dto.UserId);
            if (user == null)
                return result.AddErrorMessage("User not found");

            var identityResult = await _userRepository.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.Description).ToArray());
                return result.AddValidationErrorMessages(errors);
            }

            return result.AddSuccessMessage("Password changed successfully.");
        }

        public async Task<ResponseModel> SendResetPasswordEmailAsync(ForgotPasswordDto dto)
        {
            var result = new ResponseModel();
            var user = await _userRepository.FindByEmailAsync(dto.Email);
            if (user == null)
                return result.AddErrorMessage("User not found");

            var token = await _userRepository.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(token);
            var resetPasswordLink = $"api/Users/reset-password?userId={user.Id}&token={encodedToken}";

            //await _emailService.SendRestPasswordLinkAsync(user.Email, resetPasswordLink);
            return result.AddSuccessMessage("Reset password link generated. Please check your email");
        }

        public async Task<ResponseModel> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var result = new ResponseModel();
            if (!Guid.TryParse(dto.UserId, out var id))
                return result.AddErrorMessage("Invalid userId");

            var user = await _userRepository.FindByIdAsync(dto.UserId);
            if (user == null)
                return result.AddErrorMessage("User not found");

            var identityResult = await _userRepository.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.Description).ToArray());
                return result.AddValidationErrorMessages(errors);
            }

            return result;
        }
    }
}
