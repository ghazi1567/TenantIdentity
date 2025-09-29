using TenantIdentity.Application.DTOs;
using eBuildingBlocks.Application.Features;

namespace TenantIdentity.Application.Abstractions.Interfaces.Identity
{
    public interface IUserService
    {
        Task<ResponseModel<UserDto>> GetUserByIdAsync(string userId);
        Task<ResponseModel<UserDto>> GetUserByEmailAsync(string userEmail);
        Task<ResponseModel<List<UserDto>>> GetAllUserAsync();
        Task<ResponseModel> RegisterAsync(RegisterDto dto);

        Task<ResponseModel> ChangePasswordAsync(ChangePasswordDto dto);
        Task<ResponseModel> SendResetPasswordEmailAsync(ForgotPasswordDto dto);
        Task<ResponseModel> ResetPasswordAsync(ResetPasswordDto dto);
    }
}
