using WebApp.Models;

namespace WebApp.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCouponAsync(string code);
        Task<ResponseDTO?> GetAllCouponsAsync();

        Task<ResponseDTO?> GetCouponByIDAsync(int id);
        Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> DeleteCouponsAsync(int id);

    }
}
