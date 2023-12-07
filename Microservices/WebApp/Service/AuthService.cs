using WebApp.Models;
using WebApp.Service.IService;
using static WebApp.Utility.StaticDetails;

namespace WebApp.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.POST,
                Data = loginRequestDTO,
                URL = CouponAPIBase + "/api/auth/login"
            });
        }

        public async Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO regRequest)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.POST,
                Data = regRequest,
                URL = CouponAPIBase + "/api/auth/register"
            });
        }

        public async Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDTO regRequest)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.POST,
                Data = regRequest,
                URL = CouponAPIBase + "/api/auth/AssignRole"
            });
        }



    }
}
