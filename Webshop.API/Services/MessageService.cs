using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;
using Webshop.API.Repositories;

namespace Webshop.API.Services
{
    public class MessageService
    {
        private readonly MessageRepository _messageRepository;

        public MessageService(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<bool> SendMessageAsync(AddMessageDto newMessage)
        {
            var entity = new MessageEntity
            {
                Name = newMessage.Name,
                Email = newMessage.Email,
                Message = newMessage.Message,
                CreatedAt = DateTime.Now
            };
            return await _messageRepository.SendMessageAsync(entity);
        }
    }
}
