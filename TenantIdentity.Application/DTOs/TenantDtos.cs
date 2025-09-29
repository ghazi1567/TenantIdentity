namespace TenantIdentity.Application.DTOs
{
    public class CreateTenantDto
    {
        public string ShortName { get; set; } = default!;      // short unique code: e.g., "acme"
        public string Name { get; set; } = default!;     // display name: "Acme Inc."
        public string? Domain { get; set; }              // optional: "acme.example.com"
    }

    public class UpdateTenantDto
    {
        public string ShortName { get; set; } = default!;
        public string Name { get; set; } = default!;     // display name: "Acme Inc."
        public string? Domain { get; set; }              // optional: "acme.example.com"
        public bool IsActive { get; set; }
    }

    public class TenantDto
    {
        public TenantDto(Guid id, string shortName, string name, bool active, string? domain)
        {
            Id = id;
            ShortName = shortName;
            Name = name;
            IsActive = active;
            Domain = domain;
        }
        public Guid Id { get; set; }
        public string ShortName { get; set; } = default!;      // short unique code: e.g., "acme"
        public string Name { get; set; } = default!;     // display name: "Acme Inc."
        public string? Domain { get; set; }              // optional: "acme.example.com"
        public bool IsActive { get; set; }
    }

}
