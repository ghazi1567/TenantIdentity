using TenantIdentity.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TenantIdentity.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationRole role);
        Task<IdentityResult> UpdateAsync(ApplicationRole role);
        Task<IdentityResult> DeleteAsync(ApplicationRole role);
        Task<ApplicationRole?> FindByIdAsync(string roleId);
        Task<ApplicationRole?> FindByNameAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IList<Claim>> GetClaimsAsync(ApplicationRole role);
        Task<IdentityResult> AddClaimAsync(ApplicationRole role, Claim claim);
        Task<IdentityResult> RemoveClaimAsync(ApplicationRole role, Claim claim);
        IQueryable<ApplicationRole> Roles { get; }
        Task<List<ApplicationRole>> GetAllRoleAsync();
    }
}
