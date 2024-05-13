using CoreLibrary.Exceptions;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using CoreLibrary.ServerModels;
using RequestsLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLibrary.Services
{

    public class ExternalValuteService : IExternalValuteService
    {
        private readonly ILoggerService _loggerService;
        public ExternalValuteService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public async Task<Responce> GetValuteAsync(string url)
        {
            try
            {
                var content = await RequestsService.GetAsync<Responce>(url);

                _loggerService.Logger.Info($"Url : {url}, выполнено успешно");

                return content;
            }
            catch (HttpResponceException e)
            {
                _loggerService.Logger.Error($"URL:{url},Ошибка: {e.StatusCode}");

                return new Responce()
                {
                    Errors = new List<Error>()
                    {
                        new Error()
                        {
                            Cod = e.StatusCode,
                            Message = e.StatusDescription
                        }
                    }
                };
            }
        }

        public async Task<ResponceCrypt> GetCryptsAsync(string urlbtc)
        {
            try
            {
                var content = await RequestsService.GetAsync<ResponceCrypt>(urlbtc);

                _loggerService.Logger.Info($"Url : {urlbtc}, выполнено успешно");

                return content;
            }
            catch (HttpResponceException e)
            {
                _loggerService.Logger.Error($"URL:{urlbtc},Ошибка: {e.StatusCode}");

                return new ResponceCrypt()
                {
                    Errors = new List<Error>()
                    {
                        new Error()
                        {
                            Cod = e.StatusCode,
                            Message = e.StatusDescription
                        }
                    }
                };
            }
        }
    }
}
