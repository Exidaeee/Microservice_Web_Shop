using IdentityServer.Model;

namespace IdentityServer.Serviсe.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
