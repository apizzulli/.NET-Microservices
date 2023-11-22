using AutoMapper;
using Microservices.Services.CouponAPI.Data;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDBContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public CouponAPIController(AppDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon c = _db.Coupons.Find(id);

                if (c == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "ID not found";
                }
                else
                {
                    _response.Result = _mapper.Map<CouponDTO>(c);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
