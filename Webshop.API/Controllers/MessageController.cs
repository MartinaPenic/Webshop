using Microsoft.AspNetCore.Mvc;
using Webshop.API.Models.Dto;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(AddMessageDto newMessage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _messageService.SendMessageAsync(newMessage);

            if(result == true) { return Ok(newMessage); }
            return StatusCode(500);
        }
    }
}
