using WebApp.Models;

namespace WebApp.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO req);

    }
}
