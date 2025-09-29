using TenantIdentity.Domain.Entities;
using eBuildingBlocks.Domain.Interfaces;

namespace TenantIdentity.Domain.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant, Guid>
    {

    }
}
