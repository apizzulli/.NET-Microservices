using Microservices.Services.AuthAPI.Data;
using Microservices.Services.AuthAPI.Models;
using Microservices.Services.AuthAPI.Models.DTO;
using Microservices.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Microservices.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        public AuthService(AppDBContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJWTTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Register(RegistrationRequestDTO regRequest)
        {
            ApplicationUser newUser = new()
            {
                Email = regRequest.Email,
                UserName = regRequest.Email,
                NormalizedEmail = regRequest.Email.ToUpper(),
                Name = regRequest.Name,
                PhoneNumber = regRequest.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(newUser, regRequest.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == regRequest.Email);
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var _user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(_user, loginRequest.Password);
            if (!isValid || _user == null)
            {
                return new LoginResponseDTO() { User = null, Token = "" };
            }

            var token = _jwtTokenGenerator.GenerateToken(_user);

            UserDTO userDTO = new()
            {
                Email = _user.Email,
                ID = _user.Id,
                Name = _user.Name,
                PhoneNumber = _user.PhoneNumber
            };

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                User = userDTO,
                Token = ""
            };
            return loginResponseDTO;
        }
    }
}
