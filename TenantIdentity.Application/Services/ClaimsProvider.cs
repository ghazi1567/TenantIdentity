using TenantIdentity.Application.Abstractions.Interfaces.Identity;
using TenantIdentity.Domain.IdentityModels;
using TenantIdentity.Domain.Interfaces;
using System.Security.Claims;

namespace TenantIdentity.Application.Services
{
    public class ClaimsProvider : IClaimsProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public ClaimsProvider(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = (await _userRepository.GetClaimsAsync(user))?.ToList() ?? new List<Claim>();

            var roles = await _userRepository.GetRolesAsync(user);
            if (roles != null)
            {
                foreach (var roleName in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roleName));

                    var role = await _roleRepository.FindByNameAsync(roleName);
                    if (role != null)
                    {
                        var roleClaims = await _roleRepository.GetClaimsAsync(role);
                        if (roleClaims != null)
                        {
                            claims.AddRange(roleClaims);
                        }
                    }
                }
            }

            return claims;
        }
    }
}
