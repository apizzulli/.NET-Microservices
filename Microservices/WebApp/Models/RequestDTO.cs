using static WebApp.Utility.StaticDetails;
namespace WebApp.Models
{
    public class RequestDTO
    {
        public APIType APIType { get; set; } = APIType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
