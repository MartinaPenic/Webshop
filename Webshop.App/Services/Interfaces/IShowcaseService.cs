using Webshop.App.Models;
using Webshop.App.Models.Dto;

namespace Webshop.App.Services.Interfaces
{
    public interface IShowcaseService
    {
        Task<Showcase> GetNewShowcase();
    }
}
