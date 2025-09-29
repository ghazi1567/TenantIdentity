using eBuildingBlocks.Application.Features;
using TenantIdentity.Application.Abstractions.Interfaces;
using TenantIdentity.Application.DTOs;
using TenantIdentity.Domain.Entities;
using TenantIdentity.Domain.Interfaces;

namespace TenantIdentity.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task<ResponseModel> CreateAsync(CreateTenantDto dto)
        {
            await _tenantRepository.AddAsync(new Tenant
             (
                  dto.ShortName,
                 dto.Name,
                 dto.Domain
             ));
            var result = await _tenantRepository.SaveChangesAsync();

            return ResponseModel<TenantDto>.Ok("Tenant created successfully.");
        }

        public async Task<ResponseModel<TenantDto>> GetByIdAsync(Guid id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);

            if (tenant == null)
            {
                return ResponseModel<TenantDto>.Fail("Tenant not found.");
            }
            return ResponseModel<TenantDto>.Ok(new TenantDto(tenant.Id, tenant.ShortName, tenant.Name, tenant.IsActive, tenant.Domain),
            "Tenant Found.");
        }

        public Task<ResponseModel<TenantDto>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TenantDto>> GetByShortNameAsync(string shortName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateAsync(UpdateTenantDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
