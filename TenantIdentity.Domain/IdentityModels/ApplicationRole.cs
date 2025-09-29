using Microsoft.AspNetCore.Identity;

namespace TenantIdentity.Domain.IdentityModels
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public Guid TenantId { get; set; }
    }
}
