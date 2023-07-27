using IdentityServer.Model.Dto;
using Microsoft.Net.Http.Headers;

namespace IdentityServer.Serviсe.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
