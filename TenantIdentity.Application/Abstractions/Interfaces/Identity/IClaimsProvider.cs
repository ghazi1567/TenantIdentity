using TenantIdentity.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TenantIdentity.Application.Abstractions.Interfaces.Identity
{
    public interface IClaimsProvider
    {
        Task<IEnumerable<Claim>> GetClaimsAsync(ApplicationUser user);
    }
}
