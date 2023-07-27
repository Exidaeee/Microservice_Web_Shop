using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
