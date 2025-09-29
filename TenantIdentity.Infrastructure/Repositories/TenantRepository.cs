using TenantIdentity.Domain.Entities;
using TenantIdentity.Domain.IdentityModels;
using TenantIdentity.Domain.Interfaces;
using eBuildingBlocks.Infrastructure.Implementations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TenantIdentity.Infrastructure.Repositories
{
    public class TenantRepository(AppDbContext appDbContext) : Repository<Tenant, Guid, AppDbContext>(appDbContext), ITenantRepository
    {

    }
}
