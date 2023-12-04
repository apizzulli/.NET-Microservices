using Microservices.Services.AuthAPI.Models;

namespace Microservices.Services.AuthAPI.Service.IService
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(ApplicationUser appUser);
    }
}
