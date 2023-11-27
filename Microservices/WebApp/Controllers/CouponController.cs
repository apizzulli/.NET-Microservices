using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Service.IService;

namespace WebApp.Controllers
{
	public class CouponController : Controller
	{
		private readonly ICouponService _couponService;

		public CouponController(ICouponService couponService)
		{
			_couponService = couponService;
		}
		public async Task<IActionResult> CouponIndex()
		{
			List<CouponDTO>? list = new();
			ResponseDTO? response = await _couponService.GetAllCouponsAsync();

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		/*public async Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
		{
			APIType = APIType.POST,
                Data = couponDTO,
                URL = CouponAPIBase + "/api/coupon"

			});
        }*/
		public async Task<IActionResult> CouponCreate(CouponDTO coupon)
		{
			ResponseDTO? response = await _couponService.CreateCouponsAsync(coupon);
			/*if (response != null && response.IsSuccess)
			{

			}*/
			return View();
		}
	}
}
