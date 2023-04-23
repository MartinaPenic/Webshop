using Webshop.App.Models;


namespace Webshop.App.Services.Interfaces
{
    public interface IContactService
    {
        Task SendMessage(ContactViewModel message);
    }
}
