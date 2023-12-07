using WebApp.Models;
using WebApp.Service.IService;
using static WebApp.Utility.StaticDetails;

namespace WebApp.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.POST,
                Data = couponDTO,
                URL = CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.DELETE,
                URL = CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.GET,
                URL = CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponAsync(string code)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.GET,
                URL = CouponAPIBase + "/api/coupon/GetByCode/" + code
            });
        }

        public async Task<ResponseDTO?> GetCouponByIDAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.GET,
                URL = CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                APIType = APIType.PUT,
                Data = couponDTO,
                URL = CouponAPIBase + "/api/coupon"
            });
        }
    }
}
