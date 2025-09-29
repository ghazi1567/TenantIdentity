using TenantIdentity.Application.DTOs;
using eBuildingBlocks.Application.Features;

namespace TenantIdentity.Application.Abstractions.Interfaces.Identity
{
    public interface IAuthService
    {
        Task<ResponseModel<LoginResponseDto>> AuthenticateAsync(string email, string password);
        Task<ResponseModel<LoginResponseDto>> AuthenticateGoogleAsync(string email);
    }
}
