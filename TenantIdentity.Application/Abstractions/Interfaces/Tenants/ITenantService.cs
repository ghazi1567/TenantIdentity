using TenantIdentity.Application.DTOs;
using eBuildingBlocks.Application.Features;

namespace TenantIdentity.Application.Abstractions.Interfaces
{
    public interface ITenantService
    {
        Task<ResponseModel> CreateAsync(CreateTenantDto dto);
        Task<ResponseModel> UpdateAsync(UpdateTenantDto dto);
        Task<ResponseModel<TenantDto>> GetByIdAsync(Guid id);
        Task<ResponseModel<TenantDto>> GetByShortNameAsync(string shortName);
        Task<ResponseModel<TenantDto>> GetByNameAsync(string name);
    }
}
