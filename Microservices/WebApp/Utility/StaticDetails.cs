namespace WebApp.Utility
{
    public class StaticDetails
    {

        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public enum APIType
        {
            GET, POST, PUT, DELETE
        }
    }
}
