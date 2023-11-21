using Microservices.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace Microservices.Services.CouponAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
