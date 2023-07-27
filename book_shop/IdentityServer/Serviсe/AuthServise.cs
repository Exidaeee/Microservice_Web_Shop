using IdentityServer.Data;
using IdentityServer.Model;
using IdentityServer.Model.Dto;
using IdentityServer.Serviсe.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Serviсe
{
    public class AuthServiсe : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthServiсe(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        


        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == loginRequestDto.UserName);
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };

            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);
            UserDto userDto = new()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.Phone
            };

            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
            if (result.Succeeded) 
            {
              var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

              UserDto userDto = new()
              {
                 Email = userToReturn.Email,
                 Id = userToReturn.Id,
                 Name = userToReturn.Name,
                 Phone = userToReturn.PhoneNumber
              };
              await _db.SaveChangesAsync();
              return "";
            }
            else
            {
              return result.Errors.FirstOrDefault().Description;
            }

        }
    }
}
