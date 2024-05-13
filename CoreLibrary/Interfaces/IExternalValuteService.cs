using CoreLibrary.ServerModels;
using System.Threading.Tasks;

namespace CoreLibrary.Interfaces
{
    public interface IExternalValuteService
    {


        Task<Responce> GetValuteAsync(string url);
        Task<ResponceCrypt> GetCryptsAsync(string urlbtc);
    }
}
