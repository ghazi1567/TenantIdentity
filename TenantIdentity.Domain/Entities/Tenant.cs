using eBuildingBlocks.Domain.Models;

namespace TenantIdentity.Domain.Entities
{
    public class Tenant : AuditableEntity<Guid>
    {
        // Required by EF
        private Tenant() { }

        public Tenant(string key, string name, string? domain = null)
        {
            SetKey(key);
            SetName(name);
            SetDomain(domain);
            Activate(); // default active
        }

        public string ShortName { get; private set; } = default!;      // short unique code: e.g., "acme"
        public string Name { get; private set; } = default!;     // display name: "Acme Inc."
        public string? Domain { get; private set; }              // optional: "acme.example.com"
        public bool IsActive { get; private set; }

        // Invariants / behaviors
        public Tenant SetKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key is required.");
            if (key.Length is < 2 or > 50) throw new ArgumentException("Key must be 2–50 chars.");
            ShortName = key.Trim();
            return this;
        }

        public Tenant SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
            if (name.Length is < 2 or > 150) throw new ArgumentException("Name must be 2–150 chars.");
            Name = name.Trim();
            return this;
        }

        public Tenant SetDomain(string? domain)
        {
            Domain = string.IsNullOrWhiteSpace(domain) ? null : domain.Trim().ToLowerInvariant();
            return this;
        }

        public Tenant Activate() { IsActive = true; return this; }
        public Tenant Deactivate() { IsActive = false; return this; }
    }
}
