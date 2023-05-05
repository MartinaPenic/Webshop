using Microsoft.AspNetCore.Mvc;
using Webshop.App.Models;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                await _contactService.SendMessage(model);

                return RedirectToAction("Index", "Contact");
            }

            return View();
        }
    }
}
