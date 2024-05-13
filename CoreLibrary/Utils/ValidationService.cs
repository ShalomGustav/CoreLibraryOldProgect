using CoreLibrary.Exceptions;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using RestSharp;
using System.Collections.Generic;

namespace CoreLibrary.Utils
{
    public class ValidationService
    {
        private readonly ILoggerService _loggerService;

        public ValidationService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public bool ValideHttpResponce(IRestResponse response, RestClient client)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _loggerService.Logger.Info($"Url : {client.BaseUrl.AbsoluteUri}, выполнено успешно");

                return true;
            }

            _loggerService.Logger.Error($"URL:{client.BaseUrl.AbsoluteUri},Ошибка: {response.StatusCode}");

            throw new HttpResponceException(response.StatusCode.ToString(), response.StatusDescription);
        }

        public bool ValideLocalResponce(ResponceLocal content, List<ValuteEnum> valutes = null, List<CryptsEnum> crypts = null)
        {
            string responseString = null;

            if (valutes == null)
            {
                responseString = string.Join(", ", crypts);
            }
            else
            {
                responseString = string.Join(", ", valutes);
            }

            if (content.Errors == null)
            {
                _loggerService.Logger.Info($"Валюты : {responseString}, выполнено успешно");

                return true;
            }
            return false;
        }

        public bool ValideAuthorizationRequest(Credentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.Client.UserName) || (string.IsNullOrEmpty(credentials.Client.Password)))
            {
                return false;
            }

            return true;
        }

        public bool ValideRegisterRequest(Credentials credentials, bool required = false)
        {
            if (string.IsNullOrEmpty(credentials.Client.UserName) || (string.IsNullOrEmpty(credentials.Client.Password)))
            {
                return false;
            }

            if (required && (string.IsNullOrEmpty(credentials.Client.LastName) || (string.IsNullOrEmpty(credentials.Client.FirstName))))
            {
                return false;
            }

            return true;
        }
    }
}
