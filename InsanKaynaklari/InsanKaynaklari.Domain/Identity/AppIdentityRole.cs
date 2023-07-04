using Microsoft.AspNetCore.Identity;

namespace InsanKaynaklari.Domain.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
