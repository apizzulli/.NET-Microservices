using Newtonsoft.Json;
using System.Net;
using WebApp.Models;
using WebApp.Service.IService;
using static WebApp.Utility.StaticDetails;
namespace WebApp.Service
//BaseService - Sends Async HTTP Requests. Takes RequestDTO object containing data, request type, etc. and returns API's response
//from async call.
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO req)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("CouponAPI");
                HttpRequestMessage message = new();

                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(req.URL);
                if (req.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(req.Data));
                }
                HttpResponseMessage response = null;
                switch (req.APIType)
                {
                    case APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                response = await client.SendAsync(message);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                        break;
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                        break;
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                        break;
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                        break;
                    default:
                        var apiContent = await response.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDTO;
                }
            }
            catch (Exception e)
            {
                return new ResponseDTO { Message = e.Message.ToString(), IsSuccess = false };
            }
        }
    }
}
