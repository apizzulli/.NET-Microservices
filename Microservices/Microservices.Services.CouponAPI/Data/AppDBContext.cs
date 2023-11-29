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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponID = 1,
                CouponCode = "1G0FF",
                DiscountAmount = 10,
                MinAmount = 10

            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponID = 2,
                CouponCode = "2CB45",
                DiscountAmount = 20,
                MinAmount = 50

            });
        }
    }
}
