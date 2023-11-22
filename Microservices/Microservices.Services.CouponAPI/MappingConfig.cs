using AutoMapper;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.DTO;

namespace Microservices.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
        }
    }
}
