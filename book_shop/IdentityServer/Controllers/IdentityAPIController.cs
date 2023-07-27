using IdentityServer.Model.Dto;
using IdentityServer.Serviсe.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class IdentityAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _responseDto;
        public IdentityAPIController(IAuthService authService)
        {
            _authService = authService;
            _responseDto = new();
         
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var message = await _authService.Register(model);
            if (!string.IsNullOrEmpty(message)) 
            { 
                _responseDto.Success = false;
                _responseDto.Messenge = message;
                return BadRequest(_responseDto);
            }

            return Ok(_responseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _responseDto.Success = false;
                _responseDto.Messenge = "Невірне ім'я користувача чи пароль";
                return BadRequest(_responseDto);
            }
            
            _responseDto.Result = loginResponse;
            return Ok(_responseDto);
        }

    }
}
