using CoreLibrary.Models;

namespace CoreLibrary.Interfaces
{
    public interface IAuthorizationService
    {
        AuthorizationResponce Register(Credentials credentials);
        AuthorizationResponce Authorization(Credentials credentials);
        AuthorizationResponce GetAccount(Credentials credentials);
        AuthorizationResponce UpdateAccount(Credentials credentials);
    }
}
