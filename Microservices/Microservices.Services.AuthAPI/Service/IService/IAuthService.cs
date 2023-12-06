using Microservices.Services.AuthAPI.Models.DTO;

namespace Microservices.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO regRequest);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);

        Task<bool> AssignRole(string email, string roleName);
    }
}
