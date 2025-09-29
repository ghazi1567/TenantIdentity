using TenantIdentity.Domain.IdentityModels;
using TenantIdentity.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace TenantIdentity.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<IdentityResult> CreateAsync(ApplicationRole role)
            => _roleManager.CreateAsync(role);

        public Task<IdentityResult> UpdateAsync(ApplicationRole role)
            => _roleManager.UpdateAsync(role);

        public Task<IdentityResult> DeleteAsync(ApplicationRole role)
            => _roleManager.DeleteAsync(role);

        public Task<ApplicationRole?> FindByIdAsync(string roleId)
            => _roleManager.FindByIdAsync(roleId);

        public Task<ApplicationRole?> FindByNameAsync(string roleName)
            => _roleManager.FindByNameAsync(roleName);

        public Task<bool> RoleExistsAsync(string roleName)
            => _roleManager.RoleExistsAsync(roleName);

        public Task<IList<Claim>> GetClaimsAsync(ApplicationRole role)
            => _roleManager.GetClaimsAsync(role);

        public Task<IdentityResult> AddClaimAsync(ApplicationRole role, Claim claim)
            => _roleManager.AddClaimAsync(role, claim);

        public Task<IdentityResult> RemoveClaimAsync(ApplicationRole role, Claim claim)
            => _roleManager.RemoveClaimAsync(role, claim);

        public IQueryable<ApplicationRole> Roles => _roleManager.Roles;

        public Task<List<ApplicationRole>> GetAllRoleAsync()
            => _roleManager.Roles.ToListAsync();
    }
}
