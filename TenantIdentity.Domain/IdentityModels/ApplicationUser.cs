using Microsoft.AspNetCore.Identity;

namespace TenantIdentity.Domain.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid TenantId { get; set; }


        public ApplicationUser(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
    }
}
