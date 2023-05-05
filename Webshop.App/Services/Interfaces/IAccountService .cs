using Webshop.App.Models;

namespace Webshop.App.Services.Interfaces
{
    public interface IAccountService
    {
        Task<HttpResponseMessage> Register(RegisterViewModel model);
		Task<HttpResponseMessage> Login(LoginViewModel model);
    }
}
